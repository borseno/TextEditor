using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BorsenoTextEditor
{
    static class FileManager
    {
        private static readonly string ProjectDirectoryPath = Directory.GetCurrentDirectory();

        public static void Save(string path, string value)
        {
            Encoding fileEncoding = GetEncoding(path);

            byte[] result = fileEncoding.GetBytes(value);

            File.WriteAllText(path, String.Empty);
            using (var fileStream = File.Open(path, FileMode.OpenOrCreate))
            {
                fileStream.Seek(0, SeekOrigin.End);
                fileStream.Write(result, 0, result.Length);
            }
        }

        public static void Load(string path, TextBoxBase into)
        {
            into.Clear();
            using (var fileStream = new StreamReader(path, Encoding.Default, true))
            {
                string value = fileStream.ReadToEnd();

                into.Text = value;
            }
        }

        // may not work with UTF-8 files without BOM...
        private static Encoding GetEncoding1(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        private static Encoding GetEncoding(string filename)
        {
            using (var fileStream = new StreamReader(filename, Encoding.Default, true))
            {
                return fileStream.CurrentEncoding;
            }
        }
    }
}