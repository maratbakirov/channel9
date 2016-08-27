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
    public class Lists
    {
        public static ListDefinition RootListItem = new ListDefinition()
        {
            Url = "testlist",
            Title = "testlist",
            ContentTypesEnabled = true,
            TemplateType = BuiltInListTemplateTypeId.GenericList
        };

        public static ListDefinition RootListLibrary= new ListDefinition()
        {
            Url = "testlibrary",
            Title = "testlibrary",
            ContentTypesEnabled = true,
            TemplateType = BuiltInListTemplateTypeId.DocumentLibrary
        };


    }
}