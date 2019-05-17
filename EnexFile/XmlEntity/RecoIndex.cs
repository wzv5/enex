using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile.XmlEntity
{
    [XmlRootAttribute("recoIndex", IsNullable = false)]
    public class RecoIndex
    {
        [XmlAttribute("objID")]
        public string ObjID { get; set; }

        [XmlAttribute("objType")]
        public string ObjType { get; set; }

        [XmlAttribute("recoType")]
        public string RecoType { get; set; }

        [XmlAttribute("engineVersion")]
        public string EngineVersion { get; set; }

        [XmlAttribute("docType")]
        public string DocType { get; set; }

        [XmlAttribute("lang")]
        public string Lang { get; set; }

        [XmlAttribute("objWidth")]
        public int ObjWidth { get; set; }

        [XmlAttribute("objHeight")]
        public int ObjHeight { get; set; }
    }
}
