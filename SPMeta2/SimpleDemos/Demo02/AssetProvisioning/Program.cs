using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using Model.CSOM;
using SPMeta2.CSOM.ModelHosts;
using SPMeta2.CSOM.Services;
using SPMeta2.CSOM.Standard.ModelHandlers.Taxonomy;
using SPMeta2.CSOM.Standard.Services;
using SPMeta2.Extensions;

namespace AssetProvisioning
{
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
                    TraceHelper.TraceInformation("Configuring managed metadata");

                    var provisioningService = new StandardCSOMProvisionService();
                    var siteModel = SiteModel.BuildTaxonomyModel();

                    Console.WriteLine(siteModel.ToPrettyPrint());

                    provisioningService.RegisterModelHandlers(typeof(TaxonomyGroupModelHandler).Assembly);
                    provisioningService.DeployModel(SiteModelHost.FromClientContext(ctx), siteModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    TraceHelper.TraceInformation("Building site features");

                    var provisioningService = new CSOMProvisionService();
                    var siteModel = SiteModel.BuildSiteFeaturesModel();
                    Console.WriteLine(siteModel.ToPrettyPrint());

                    provisioningService.DeployModel(SiteModelHost.FromClientContext(ctx), siteModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    TraceHelper.TraceInformation("Building site fields");

                    var provisioningService = new StandardCSOMProvisionService();
                    var siteModel = SiteModel.BuildFieldsModel();
                    Console.WriteLine(siteModel.ToPrettyPrint());

                    provisioningService.DeployModel(SiteModelHost.FromClientContext(ctx), siteModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    TraceHelper.TraceInformation("Building site content types");

                    var provisioningService = new StandardCSOMProvisionService();
                    var siteModel = SiteModel.BuildContentTypesModel();
                    Console.WriteLine(siteModel.ToPrettyPrint());

                    provisioningService.DeployModel(SiteModelHost.FromClientContext(ctx), siteModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    TraceHelper.TraceInformation("Building web root model ");

                    var provisioningService = new StandardCSOMProvisionService();
                    var webModel = SiteModel.BuildWebRootModel();
                    Console.WriteLine(webModel.ToPrettyPrint());

                    provisioningService.DeployModel(SiteModelHost.FromClientContext(ctx), webModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    TraceHelper.TraceInformation("Building web root files and modules");

                    var provisioningService = new StandardCSOMProvisionService();
                    var webModel = Model.FIles.BuildFilesModel();
                    Console.WriteLine(webModel.ToPrettyPrint());

                    provisioningService.DeployModel(WebModelHost.FromClientContext(ctx), webModel);
                }
                using (ClientContext ctx = GetAuthenticatedContext())
                {
                    TraceHelper.TraceInformation("Building pages");

                    var provisioningService = new StandardCSOMProvisionService();
                    var webModel = Model.Pages.BuildPagesModel();
                    Console.WriteLine(webModel.ToPrettyPrint());

                    provisioningService.DeployModel(WebModelHost.FromClientContext(ctx), webModel);
                }
            }
            catch (Exception ex)
            {
                TraceHelper.TraceError("an error has occured, message:{0}", ex);
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

