using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Enumerations;

namespace Model
{
    public static class Pages
    {
        #region properties

        public static WikiPageDefinition About = new WikiPageDefinition
        {
            Title = "About",
            FileName = "about.aspx"
        };

        public static WikiPageDefinition FAQ = new WikiPageDefinition
        {
            Title = "FAQ",
            FileName = "FAQ.aspx"
        };

        public static WebPartPageDefinition KPI = new WebPartPageDefinition
        {
            Title = "KPI",
            FileName = "KPI.aspx",
            PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
        };

        public static WebPartPageDefinition MyTasks = new WebPartPageDefinition
        {
            Title = "MyTasks",
            FileName = "MyTasks.aspx",
            PageLayoutTemplate = BuiltInWebPartPageTemplates.spstd1
        };


        #endregion
    }
}
