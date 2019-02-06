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

        private static Encoding GetEncoding(string filename)
        {
            using (var fileStream = new StreamReader(filename, Encoding.Default, true))
            {
                return fileStream.CurrentEncoding;
            }
        }
    }
}