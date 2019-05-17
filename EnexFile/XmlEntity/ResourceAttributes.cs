using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile.XmlEntity
{
    public class ResourceAttributes
    {
        [XmlElement("source-url")]
        public string SourceUrl { get; set; }

        [XmlElement("timestamp")]
        public string Timestamp { get; set; }

        [XmlElement("latitude")]
        public string Latitude { get; set; }

        [XmlElement("longitude")]
        public string Longitude { get; set; }

        [XmlElement("altitude")]
        public string Altitude { get; set; }

        [XmlElement("camera-make")]
        public string CameraMake { get; set; }

        [XmlElement("camera-model")]
        public string CameraModel { get; set; }

        [XmlElement("reco-type")]
        public string RecoType { get; set; }

        [XmlElement("file-name")]
        public string FileName { get; set; }

        [XmlElement("attachment")]
        public bool Attachment { get; set; }

        [XmlElement("application-data")]
        public ApplicationData[] ApplicationData { get; set; }
    }
}
