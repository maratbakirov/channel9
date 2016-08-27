using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;
using SPMeta2.Models;
using SPMeta2.Syntax.Default;

namespace Model
{
    public static class Pages
    {
        public static WebPartDefinition GettingStarted = new SPMeta2.Definitions.WebPartDefinition
        {
            Title = "Getting started with site",
            Id = "spmGettingStarted",
            ZoneId = "Main",
            ZoneIndex = 100,
            WebpartXmlTemplate = AssetProvisioning.ResourceReader.ReadFromResourceName("Templates.Webparts.Get started with your site.webpart")
        };

        public static WebPartDefinition ContentEditor = new SPMeta2.Definitions.WebPartDefinition
        {
            Title = "SPMeta2 Content Editor Webpart",
            Id = "spmContentEditorWebpart",
            ZoneId = "Main",
            ZoneIndex = 200,
            WebpartXmlTemplate = AssetProvisioning.ResourceReader.ReadFromResourceName("Templates.Webparts.Content Editor.dwp")
        };

        public static WebPartPageDefinition WebPartPage = new WebPartPageDefinition
        {
            Title = "Getting started",
            FileName = "Getting-Started.aspx",
            PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
        };




        public static ModelNode BuildPagesModel()
        {

            var model = SPMeta2Model
                .NewWebModel(web =>
                {
                    web
                            .AddList(BuiltInListDefinitions.SitePages, list =>
                            {
                                list
                                    .AddWebPartPage(WebPartPage, page =>
                                    {
                                        page
                                            .AddWebPart(GettingStarted)
                                            .AddWebPart(ContentEditor);
                                    });
                            });
                });
            return model;
        }
    }


}
