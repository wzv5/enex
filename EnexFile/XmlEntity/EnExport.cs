using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile.XmlEntity
{
    [XmlRootAttribute("en-export", IsNullable = false)]
    public class EnExport
    {
        [XmlAttribute("export-date")]
        public string ExportDate { get; set; }

        [XmlAttribute("application")]
        public string Application { get; set; }

        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlElement("note")]
        public Note[] Notes { get; set; }
    }
}
