using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Enumerations;
using SPMeta2.Models;
using SPMeta2.Standard.Syntax;
using SPMeta2.Syntax.Default;

namespace Model.CSOM
{
    public class SiteModel
    {
        public static ModelNode BuildTaxonomyModel()
        {

            var siteModel = SPMeta2Model.NewSiteModel(

                site =>
                {
                    site.AddTaxonomyTermStore(Taxonomy.TermStore,

                        termStore =>
                        {
                            termStore.AddTaxonomyTermGroup(Taxonomy.RootGroup,
                                group =>
                                {
                                    group.AddTaxonomyTermSet(Taxonomy.Location,
                                        termSet =>
                                        {
                                            termSet.AddTaxonomyTerm(Taxonomy.RootTerm,
                                                term =>
                                                {
                                                    term.AddTaxonomyTerm(Taxonomy.SubTerm1,
                                                        term1 =>
                                                        {

                                                            term1.AddTaxonomyTerm(Taxonomy.SubTerm2);
                                                        }
                                                    );
                                                }
                                                );
                                        });
                                });
                        });
                }
                );
            return siteModel;
        }

        public static ModelNode BuildSiteFeaturesModel()
        {

            var siteModel = SPMeta2Model.NewSiteModel(

                site =>
                {
                    site.AddSiteFeature(BuiltInSiteFeatures.SharePointServerPublishingInfrastructure
                        .Inherit(
                            x => { x.Enable = true;
                                     x.ForceActivate = true;
                            }
                        ));
                }
                );
            return siteModel;
        }

        public static ModelNode BuildFieldsModel()
        {

            var siteModel = SPMeta2Model.NewSiteModel(

                site =>
                {
                    site.AddField(Fields.MyTaxonomyfield);
                    site.AddField(Fields.ClientId);
                    site.AddField(Fields.ClientName);
                    site.AddField(Fields.ClientComment);
                    site.AddField(Fields.ClientIsNonProfit);
                    site.AddField(Fields.ClinentLoginLink);
                    site.AddField(Fields.Dept);
                    site.AddField(Fields.Loan);
                    site.AddField(Fields.Revenue);
                }
                );
            return siteModel;
        }

        public static ModelNode BuildContentTypesModel()
        {

            var siteModel = SPMeta2Model.NewSiteModel(

                site =>
                {
                    site.AddContentType(ContentTypes.Item,
                        contentType =>
                        {
                            contentType.AddContentTypeFieldLink(Fields.MyTaxonomyfield);
                            contentType.AddContentTypeFieldLink(Fields.ClientId);
                            contentType.AddContentTypeFieldLink(Fields.ClientName);
                            contentType.AddContentTypeFieldLink(Fields.ClientComment);
                            contentType.AddContentTypeFieldLink(Fields.ClientIsNonProfit);
                            contentType.AddContentTypeFieldLink(Fields.Dept);
                            contentType.AddContentTypeFieldLink(Fields.Loan);
                            contentType.AddContentTypeFieldLink(Fields.Revenue);
                        }
                        );
                    site.AddContentType(ContentTypes.SubItem,
                        contentType =>
                        {
                            contentType.AddContentTypeFieldLink(Fields.ClinentLoginLink);
                        });
                    site.AddContentType(ContentTypes.Document,
                        contentType =>
                        {
                            contentType.AddContentTypeFieldLink(Fields.MyTaxonomyfield);
                            contentType.AddContentTypeFieldLink(Fields.ClientId);
                            contentType.AddContentTypeFieldLink(Fields.ClientName);
                            contentType.AddContentTypeFieldLink(Fields.ClientComment);
                            contentType.AddContentTypeFieldLink(Fields.ClientIsNonProfit);
                            contentType.AddContentTypeFieldLink(Fields.Dept);
                            contentType.AddContentTypeFieldLink(Fields.Loan);
                            contentType.AddContentTypeFieldLink(Fields.Revenue);
                        }
                        );
                    site.AddContentType(ContentTypes.SubDocument,
                        contentType =>
                        {
                            contentType.AddContentTypeFieldLink(Fields.ClinentLoginLink);
                        });
                }
                );
            return siteModel;
        }

        public static ModelNode BuildWebRootModel()
        {
            var webModel = SPMeta2Model.NewWebModel(

                web =>
                {
                    web.AddWebFeature(
                        BuiltInWebFeatures.MinimalDownloadStrategy.Inherit(
                            x =>
                            {
                                x.Enable = false;
                                x.ForceActivate = false;
                            })
                        );
                    web.AddList(Lists.RootListItem,
                            list =>
                            {
                                list.AddContentTypeLink(ContentTypes.Item);
                                list.AddContentTypeLink(ContentTypes.SubItem);
                                list.AddRemoveContentTypeLinks(ContentTypes.RemoveItemContentTypeDefinition);
                            }
                        );
                    web.AddList(Lists.RootListLibrary,
                            list =>
                            {
                                list.AddContentTypeLink(ContentTypes.Document);
                                list.AddContentTypeLink(ContentTypes.SubDocument);
                                list.AddRemoveContentTypeLinks(ContentTypes.RemoveIDocumentContentTypeDefinition);
                            }
                        );
                    web.AddList(BuiltInListDefinitions.SitePages, pages =>
                    {
                        pages
                            .AddWebPartPage(Pages.KPI)
                            .AddWebPartPage(Pages.MyTasks)
                            .AddWikiPage(Pages.About)
                            .AddWikiPage(Pages.FAQ);
                    });
                }
                );
            return webModel;
        }


    }
}
