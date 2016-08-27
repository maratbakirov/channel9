using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPMeta2.Definitions;
using SPMeta2.Definitions.ContentTypes;
using SPMeta2.Definitions.Fields;
using SPMeta2.Enumerations;
using SPMeta2.Standard.Definitions.Fields;
using SPMeta2.Standard.Definitions.Taxonomy;
using SPMeta2.Syntax.Default;

namespace Model
{
    public class ContentTypes
    {
        public static ContentTypeDefinition Item = new ContentTypeDefinition()
        {
            Id = new Guid("{C3922A2C-47E7-4033-82EB-328E7B79E466}"),
            Name = "DemoItem",
            ParentContentTypeId = BuiltInContentTypeId.Item,
            Group = Consts.DefaultMetadataGroup
        };

        public static ContentTypeDefinition SubItem = new ContentTypeDefinition()
        {
            Id = new Guid("{89AFF938-01D1-4B43-BBF8-D08AF3A89F1B}"),
            Name = "DemoSubItem",
            ParentContentTypeId = Item.GetContentTypeId(),
            Group = Consts.DefaultMetadataGroup
        };
        public static ContentTypeDefinition Document = new ContentTypeDefinition()
        {
            Id = new Guid("{29DB8B44-0ED9-4286-8066-B506E3B53A4E}"),
            Name = "DemoDocument",
            ParentContentTypeId = BuiltInContentTypeId.Document,
            Group = Consts.DefaultMetadataGroup
        };

        public static ContentTypeDefinition SubDocument = new ContentTypeDefinition()
        {
            Id = new Guid("{377DE6EF-0929-4E1F-8EE9-F7E8D3BD628A}"),
            Name = "DemoSubDocument",
            ParentContentTypeId = Document.GetContentTypeId(),
            Group = Consts.DefaultMetadataGroup
        };

        public static RemoveContentTypeLinksDefinition RemoveItemContentTypeDefinition
        {
            get
            {
                return new RemoveContentTypeLinksDefinition()
                {
                    ContentTypes = new List<ContentTypeLinkValue>()
                    {
                        new ContentTypeLinkValue() {ContentTypeName = "Item"}
                    }
                };
            }
        }

        public static RemoveContentTypeLinksDefinition RemoveIDocumentContentTypeDefinition
        {
            get
            {
                return new RemoveContentTypeLinksDefinition()
                {
                    ContentTypes = new List<ContentTypeLinkValue>()
                    {
                        new ContentTypeLinkValue() {ContentTypeName = "Document"}
                    }
                };
            }
        }

    }
}