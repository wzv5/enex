using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile.XmlEntity
{
    public class NoteAttributes
    {
        [XmlElement("subject-date")]
        public string SubjectDate { get; set; }

        [XmlElement("latitude")]
        public string Latitude { get; set; }

        [XmlElement("longitude")]
        public string Longitude { get; set; }

        [XmlElement("altitude")]
        public string Altitude { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("source")]
        public string Source { get; set; }

        [XmlElement("source-url")]
        public string SourceUrl { get; set; }

        [XmlElement("source-application")]
        public string SourceApplication { get; set; }

        [XmlElement("task-date")]
        public string TaskDate { get; set; }

        [XmlElement("task-complete-date")]
        public string TaskCompleteDate { get; set; }

        [XmlElement("task-due-date")]
        public string TaskDueDate { get; set; }

        [XmlElement("place-name")]
        public string PlaceName { get; set; }

        [XmlElement("content-class")]
        public string ContentClass { get; set; }

        [XmlElement("application-data")]
        public ApplicationData[] ApplicationData { get; set; }
    }
}
