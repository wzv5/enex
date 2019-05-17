using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using HtmlAgilityPack;

namespace EnexFile.XmlEntity
{
    public class Note
    {
        [XmlElement("title", IsNullable = false)]
        public string Title { get; set; }

        [XmlElement("content", IsNullable = false)]
        public string Content { get; set; }

        [XmlElement("created")]
        public string Created { get; set; }

        [XmlElement("updated")]
        public string Updated { get; set; }

        [XmlElement("tag")]
        public string[] Tag { get; set; }

        [XmlElement("note-attributes")]
        public NoteAttributes NoteAttributes { get; set; }

        [XmlElement("resource")]
        public Resource[] Resource { get; set; }
    }
}
