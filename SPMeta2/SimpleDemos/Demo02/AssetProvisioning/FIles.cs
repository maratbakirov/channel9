using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.BuiltInDefinitions;
using SPMeta2.Definitions;
using SPMeta2.Models;
using SPMeta2.Syntax.Default;

namespace Model
{
    public static class FIles
    {
        // Step 1, define security groups
        public static ModuleFileDefinition HelloModuleFile = new ModuleFileDefinition
        {
            FileName = "hello-module.txt",
            Content = Encoding.UTF8.GetBytes("A hello world module file provision.")
        };
        
        public static ModuleFileDefinition AngularFile = new ModuleFileDefinition
        {
            FileName = "angular.min.js",

            Content = Encoding.UTF8.GetBytes(AssetProvisioning.ResourceReader.ReadFromResourceName("Modules.js.angular.min.js"))
        };

        public static ModuleFileDefinition JQueryFile = new ModuleFileDefinition
        {
            FileName = "jquery-1.11.1.min.js",
            Content = Encoding.UTF8.GetBytes(AssetProvisioning.ResourceReader.ReadFromResourceName("Modules.js.jquery-1.11.1.min.js"))
        };

        public static FolderDefinition JsFolder = new FolderDefinition { Name = "spmeta2-custom-js" };


        public static ModelNode BuildFilesModel()
        {

            var model = SPMeta2Model
                .NewWebModel(web =>
                {
                    web
                        .AddList(BuiltInListDefinitions.StyleLibrary, list =>
                        {
                            list
                                .AddModuleFile(HelloModuleFile)
                                .AddFolder(JsFolder, folder =>
                                {
                                    folder
                                        .AddModuleFile(AngularFile)
                                        .AddModuleFile(JQueryFile);
                                });
                        });
                });
            return model;
        }
    }


}
