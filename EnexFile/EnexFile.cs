using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnexFile
{
    public class EnexFile
    {
        public XmlEntity.EnExport Result { get; private set; }

        public XmlEntity.EnExport Load(string filename)
        {
            using (var stream = new StreamReader(filename))
            {
                var xmlSerializer = new XmlSerializer(typeof(XmlEntity.EnExport));
                Result = xmlSerializer.Deserialize(stream) as XmlEntity.EnExport;
                return Result;
            }
        }

        public static void DumpSingle(XmlEntity.Note note, string dir, MarkdownConfig config = null)
        {
            if (config == null)
            {
                config = new MarkdownConfig();
            }

            Directory.CreateDirectory(Path.Combine(dir, config.AttachmentPath));

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(note.Content);
            var html = doc.DocumentNode.SelectSingleNode("/en-note").InnerHtml;
            var converter = new ReverseMarkdown.Converter(config);
            converter.Register("en-media", new MarkdownConverters.EnMedia(note));
            converter.Register("en-todo", new MarkdownConverters.EnTodo());
            var sb = new StringBuilder();
            if (config.InsertTitle)
            {
                sb.AppendLine($"# {note.Title}");
                sb.AppendLine();
            }
            sb.Append(System.Web.HttpUtility.HtmlDecode(converter.Convert(html)));

            if (note.Resource != null)
            {
                foreach (var item in note.Resource)
                {
                    sb.AppendLine();
                    if (config.InlineImage && item.Mime.ToLower().StartsWith("image/"))
                    {
                        sb.AppendLine($"[{item.Data.Hash}]: data:{item.Mime};base64,{item.Data.Base64}");
                    }
                    else
                    {
                        var filename = item.FileName;
                        if (File.Exists(Path.Combine(dir, config.AttachmentPath, filename)))
                        {
                            var ext = Path.GetExtension(filename);
                            var name = Path.GetFileNameWithoutExtension(filename);
                            var n = 1;
                            while (File.Exists(Path.Combine(dir, config.AttachmentPath, $"{name}_{n}{ext}")))
                            {
                                ++n;
                            }
                            filename = $"{name}_{n}{ext}";
                        }
                        sb.AppendLine($"[{item.Data.Hash}]: {Path.Combine(config.AttachmentPath, filename)} ({item.FileName})");
                        File.WriteAllBytes(Path.Combine(dir, config.AttachmentPath, filename), item.Data.Content);
                    }
                }
            }
            
            var result = Regex.Replace(sb.ToString(), "(?:" + Environment.NewLine + "){3,}", $"{Environment.NewLine}{Environment.NewLine}");
            result = result.Trim();

            string mdfilename = config.UUIDFilename ? Guid.NewGuid().ToString() : Utility.SafeFileName(note.Title);
            File.WriteAllText(Path.Combine(dir, Utility.SafeFileName($"{mdfilename}.md")), result);
        }

        public void DumpAll(string dir, MarkdownConfig config = null)
        {
            foreach (var item in Result.Notes)
            {
                DumpSingle(item, dir, config);
            }
        }
    }
}
