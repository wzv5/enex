using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile.XmlEntity
{
    public class Data
    {
        [XmlAttribute("encoding")]
        public string Encoding { get; set; }

        [XmlText]
        public string _base64str;

        [XmlIgnore]
        public string Base64
        {
            get => Regex.Replace(_base64str, @"[^a-zA-Z0-9+/=]", "");
        }

        [XmlIgnore]
        public byte[] Content
        {
            get => Convert.FromBase64String(Base64);
        }

        [XmlIgnore]
        public string Hash
        {
            get
            {
                using (var md5 = MD5.Create())
                {
                    var data = md5.ComputeHash(Content);
                    var sb = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                    {
                        sb.Append(data[i].ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
        }
    }
}
