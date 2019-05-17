using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile.XmlEntity
{
    public class Resource
    {
        [XmlElement("data", IsNullable = false)]
        public Data Data { get; set; }

        [XmlElement("mime", IsNullable = false)]
        public string Mime { get; set; }

        [XmlElement("width")]
        public string Width { get; set; }

        [XmlElement("height")]
        public string Height { get; set; }

        [XmlElement("duration")]
        public string Duration { get; set; }

        [XmlElement("recognition")]
        public string _recognition;

        [XmlIgnore]
        public RecoIndex Recognition
        {
            get
            {
                try
                {
                    using (var stream = new StringReader(_recognition))
                    {
                        return new XmlSerializer(typeof(RecoIndex)).Deserialize(stream) as RecoIndex;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        [XmlElement("resource-attributes")]
        public ResourceAttributes ResourceAttributes { get; set; }

        [XmlElement("alternate-data")]
        public Data AlternateData { get; set; }

        [XmlIgnore]
        public string FileName
        {
            get
            {
                var filename = ResourceAttributes?.FileName ?? "";
                var name = Path.GetFileNameWithoutExtension(filename).Trim();
                var ext = Path.GetExtension(filename).Trim();
                if (name == "")
                {
                    name = Data.Hash;
                }
                if (ext == "")
                {
                    ext = Utility.MimeToExt(Mime);
                }
                return Utility.SafeFileName($"{name}{ext}");
            }
        }
    }
}
