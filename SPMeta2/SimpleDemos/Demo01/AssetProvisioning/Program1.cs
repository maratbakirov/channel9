﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.CSOM.ModelHosts;
using SPMeta2.CSOM.Services;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Extensions;
using SPMeta2.Models;
using SPMeta2.Syntax.Default;

namespace AssetProvisioning
{

    public class Model
    {
        public static SecurityGroupDefinition TestSecurityGroup = new SecurityGroupDefinition()
        {
            Name = "TestSecurityGroup",
            Owner = "TestSecurityGroup",
            AllowMembersEditMembership = true,
            AllowRequestToJoinLeave = false,
            //AllowRequestToJoinLeave = true,
            Description = "test group",
        };

        public static Guid MySampleContentTypeGuid = new Guid("{35CB73AD-B123-44E9-9138-8C86EEC1E87E}");
        public static ContentTypeDefinition MySampleContentType = new ContentTypeDefinition()
        {
            ParentContentTypeId = BuiltInContentTypeId.Item,
            Name = "DemoContact",
            Id = MySampleContentTypeGuid,
            Group = "M2Demo"
        };

        public static ModelNode BuildSiteModel()
        {
            var siteModel = SPMeta2Model.NewSiteModel(
                site =>
                {
                    site.AddSecurityGroup(TestSecurityGroup);
                    site.AddContentType(MySampleContentType, contentype =>
                    {
                        contentype.AddContentTypeFieldLink(BuiltInFieldId.Description);
                        contentype.AddContentTypeFieldLink(BuiltInFieldId.StartDate);
                        contentype.AddContentTypeFieldLink(BuiltInFieldId.EndDate);
                    });
                }
                );
            return siteModel;
        }

        public static ModelNode BuilWebModel()
        {
            var siteModel = SPMeta2Model.NewWebModel(

                web=>
                {
                    web.AddWebFeature(BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(
                        x =>
                        {
                            x.Enable = false;
                            x.ForceActivate = true;
                        }
                        ));
                }
                );
            return siteModel;
        }
    }

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {

                ReadSettings();
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();
                    Console.WriteLine(ctx.Web.Url);

                    TraceHelper.TraceInformation("Configuring site");

                    var provisioningService = new CSOMProvisionService();
                    var siteModel = Model.BuildSiteModel();

                    var str1 = siteModel.ToDotGraph();
                    var str2 = siteModel.ToPrettyPrint();

                    Console.WriteLine(str2);

                    System.IO.File.WriteAllText("sitemode.txt",str1);

                    provisioningService.DeployModel(SiteModelHost.FromClientContext(ctx), siteModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    ctx.Load(ctx.Web);
                    ctx.ExecuteQuery();
                    Console.WriteLine(ctx.Web.Url);

                    TraceHelper.TraceInformation("Configuring web");

                    var provisioningService = new CSOMProvisionService();
                    var webModel = Model.BuilWebModel();

                    provisioningService.DeployModel(WebModelHost.FromClientContext(ctx), webModel);

                }
            }
            catch (Exception ex)
            {
                TraceHelper.TraceError("an error has occured, message:{0}", ex.Message);
            }


        }

        static bool sharepointonline;

        private static bool ReadSettings()
        {
            var sharepointonlinesetting = ConfigurationManager.AppSettings["SharepointOnline"];
            bool.TryParse(sharepointonlinesetting, out sharepointonline);
            return sharepointonline;
        }

        #region auth
        private static ClientContext GetAuthenticatedContext()
        {
            var siteUrl = ConfigurationManager.AppSettings["siteurl"];
            var context = new ClientContext(siteUrl);
            if (sharepointonline)
            {
                SecureString password = GetPassword();
                context.Credentials = new SharePointOnlineCredentials(ConfigurationManager.AppSettings["sharepointonlinelogin"],
                    password);
            }
            return context;
        }

        private static SecureString storedPassword = null;
        private static SecureString GetPassword()
        {
            if (storedPassword == null)
            {
                Console.WriteLine("Please enter your password");
                storedPassword = GetConsoleSecurePassword();
                Console.WriteLine();
            }
            return storedPassword;
        }


        private static SecureString GetConsoleSecurePassword()
        {
            SecureString pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    pwd.RemoveAt(pwd.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }
        #endregion

    }
}

