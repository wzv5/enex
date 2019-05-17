using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnexFile.MarkdownConverters
{
    public class EnMedia : ReverseMarkdown.Converters.IConverter
    {
        private XmlEntity.Note _note;
        public EnMedia(XmlEntity.Note note)
        {
            _note = note;
        }

        public string Convert(HtmlAgilityPack.HtmlNode node)
        {
            var hash = node.GetAttributeValue("hash", "");
            var query = from i in _note.Resource
                        where i.Data.Hash == hash
                        select i;
            var res = query.FirstOrDefault();
            var name = res.FileName;
            name = name.Replace("[", @"\[").Replace("]", @"\]");

            if (hash.Length == 32)
            {
                if (node.GetAttributeValue("type", "").ToLower().StartsWith("image/"))
                {
                    return $"![{name}][{hash}]";
                }
                else
                {
                    return $"[{name}][{hash}]";
                }
            }

            return node.OuterHtml;
        }
    }

    public class EnTodo : ReverseMarkdown.Converters.IConverter
    {
        public string Convert(HtmlAgilityPack.HtmlNode node)
        {
            var x = node.GetAttributeValue("checked", false) ? "x" : " ";
            return $"- [{x}] ";
        }
    }
}
