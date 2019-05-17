using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnexFile
{
    public class Utility
    {
        public static string MimeToExt(string mime)
        {
            if (string.IsNullOrWhiteSpace(mime))
            {
                return ".unknown";
            }

            var mimemap = new Dictionary<string, string>();
            //mimemap.Add("image/png", ".png");
            if (mimemap.ContainsKey(mime))
            {
                return mimemap[mime];
            }
            else
            {
                var a = mime.Split('/');
                return a.Length == 1 ? $".{a[0]}" : $".{a.Last()}";
            }
        }

        public static string SafeFileName(string filename)
        {
            foreach (var item in Path.GetInvalidPathChars())
            {
                filename = filename.Replace(item.ToString(), "");
            }
            foreach (var item in Path.GetInvalidFileNameChars())
            {
                filename = filename.Replace(item.ToString(), "");
            }
            return filename;
        }
    }
}
