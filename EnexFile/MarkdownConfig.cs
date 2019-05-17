using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnexFile
{
    public class MarkdownConfig : ReverseMarkdown.Config
    {
        // 附件路径，默认为 "files/"
        public string AttachmentPath { get; set; }

        // 是否内联保存图片，即在 markdown 文件内保存 base64 编码的图片，默认为 false
        public bool InlineImage { get; set; }

        // 是否自动在开头插入标题，默认为 false
        public bool InsertTitle { get; set; }

        // 是否使用唯一的 UUID 作为 markdown 文件名，默认为 false，使用原始标题作为文件名
        public bool UUIDFilename { get; set; }

        public MarkdownConfig()
        {
            TableWithoutHeaderRowHandling = TableWithoutHeaderRowHandlingOption.EmptyRow;
            GithubFlavored = true;
            AttachmentPath = "files/";
            InlineImage = false;
            InsertTitle = false;
            UUIDFilename = false;
        }
    }
}
