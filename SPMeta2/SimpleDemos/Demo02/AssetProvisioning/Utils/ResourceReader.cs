using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetProvisioning
{
    public static class ResourceReader
    {
        public static string ReadFromResourceName(string name)
        {
            var ns = "AssetProvisioning";

            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("{0}.{1}", ns, name))))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
