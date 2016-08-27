using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Definitions.Fields;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Definitions.Fields;
using SPMeta2.Standard.Definitions.Taxonomy;

namespace Model
{
    public class Fields
    {

        public static TaxonomyFieldDefinition MyTaxonomyfield = new TaxonomyFieldDefinition
        {
            InternalName = "MyTaxonomyField2",
            Title = "MyTaxonomyField2",
            Group =  Consts.DefaultMetadataGroup,
            Id = new Guid("{29E4CBD2-6CA7-47E7-9B5B-FF7725949D58}"),
            //TermSetId = Taxonomy.Location.Id,
            TermSetName = "Location",
            TermSetLCID = 1033,
            //TermId = Taxonomy.RootTerm.Id,
            UseDefaultSiteCollectionTermStore = true
        };


        //public static FieldDefinition Location = new TaxonomyFieldDefinition()
        //{
        //    Id = new Guid("{A19B01FF-36FF-4650-861D-B48FE4EE7608}"),
        //    Title = "Location",
        //    InternalName = "RIO_Location",
        //    Description = "",
        //    Group = Consts.GroupName,
        //    Required = false,
        //    UseDefaultSiteCollectionTermStore = true,
        //    TermSetId = Taxonomy.Location.Id,
        //    TermSetLCID = 1033,
        //    TermSetName = "Location",
        //    //TermLCID = 1033,
        //    //TermId = Taxonomy.RootTerm.Id,
        //    //TermName = "Root",
        //};


        public static FieldDefinition ClientId = new FieldDefinition
        {
            Id = new Guid("1d20b513-0095-4735-a68d-c5c972494afc"),
            Title = "Client ID",
            InternalName = "clnt_ClientId",
            Group = Consts.DefaultMetadataGroup,
            FieldType = BuiltInFieldTypes.Text
        };

        public static FieldDefinition ClientName = new TextFieldDefinition()
        {
            Id = new Guid("2a121dbf-ad68-4f2c-af49-f8671dfd4bf7"),
            Title = "Client Name",
            InternalName = "clnt_ClientName",
            Group = Consts.DefaultMetadataGroup
        };

        public static FieldDefinition ClientComment = new NoteFieldDefinition()
        {
            Id = new Guid("0d122a96-24ba-4776-a68c-32cf32bb1150"),
            Title = "Client Comment",
            InternalName = "clnt_ClientComment",
            Group = Consts.DefaultMetadataGroup,
            RichText = true,
            RichTextMode = BuiltInRichTextMode.FullHtml
        };

        public static FieldDefinition ClientIsNonProfit = new BooleanFieldDefinition()
        {
            Id = new Guid("f8e98eee-842c-48a3-a3ad-9a204e809256"),
            Title = "Client Is Non Profit",
            InternalName = "clnt_ClientIsNonProfit",
            Group = Consts.DefaultMetadataGroup,
            FieldType = BuiltInFieldTypes.Boolean
        };
        
        public static FieldDefinition Dept = new CurrencyFieldDefinition()
        {
            Id = new Guid("c2a3f0fb-024c-43cd-8502-55ce866fb0ec"),
            Title = "Client Dept",
            InternalName = "clnt_Dept",
            Group = Consts.DefaultMetadataGroup,
            CurrencyLocaleId = 1033
        };

        public static FieldDefinition Loan = new CurrencyFieldDefinition
        {
            Id = new Guid("187ea759-a615-4638-9a0a-e9980327eed6"),
            Title = "Client Loan",
            InternalName = "clnt_Loan",
            Group = Consts.DefaultMetadataGroup,
        };

        public static FieldDefinition Revenue = new CurrencyFieldDefinition
        {
            Id = new Guid("306dc168-bdf1-479c-9c41-40c977634dbf"),
            Title = "Client Revenue",
            InternalName = "clnt_Revenue",
            Group = Consts.DefaultMetadataGroup
        };


        public static FieldDefinition ClinentLoginLink = new UserFieldDefinition()
        {
            Id = new Guid("d3526287-8657-4be5-a7de-7633441d0213"),
            Title = "Client Login Link",
            InternalName = "clnt_LoginLink",
            Group = Consts.DefaultMetadataGroup,
            AllowMultipleValues = false,
            SelectionMode = BuiltInFieldUserSelectionMode.PeopleOnly
        };

    }
}