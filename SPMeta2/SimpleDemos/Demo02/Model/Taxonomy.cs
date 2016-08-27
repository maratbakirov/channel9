using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Standard.Definitions.Taxonomy;

namespace Model
{
    public class Taxonomy
    {

        public static TaxonomyTermStoreDefinition TermStore = new TaxonomyTermStoreDefinition
        {
            UseDefaultSiteCollectionTermStore = true,
        };

        public static TaxonomyTermGroupDefinition RootGroup = new TaxonomyTermGroupDefinition
        {
            Name = "RootGroup1",
            //Id = new Guid("{0BA27B3B-300F-48B8-AA4E-73FC1A140118}")
        };
        public static TaxonomyTermSetDefinition Location = new TaxonomyTermSetDefinition
        {
            Name = "Location",
            //Id = new Guid("{85EAF349-395B-4D00-9064-5FB46A52FC98}"),
            LCID = 1033
        };

        public static TaxonomyTermDefinition RootTerm = new TaxonomyTermDefinition
        {
            Name = "Root",
            //Id = new Guid("{16068867-9F84-4CC1-91DC-2300026EA581}"),
            LCID = 1033
        };
        public static TaxonomyTermDefinition SubTerm1 = new TaxonomyTermDefinition
        {
            Name = "SubTerm1",
            //Id = new Guid("{E44898F4-D1AF-4ADB-A6CA-586E6DCBF9C3}"),
            LCID = 1033
        };
        public static TaxonomyTermDefinition SubTerm2 = new TaxonomyTermDefinition
        {
            Name = "SubTerm1.1",
            //Id = new Guid("{643BBA8E-2404-4352-994B-A111F01EEBB7}"),
            LCID = 1033
        };

    }
}
