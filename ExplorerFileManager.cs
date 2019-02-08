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
    sealed class ExplorerFileManager : IFileManager
    {
        public void Save(string path, string value)
        {
            Encoding fileEncoding = EncodingHelper.GetFileEncoding(path) ?? Encoding.Default;

            byte[] result = fileEncoding.GetBytes(value);

            File.WriteAllText(path, String.Empty);
            using (var fileStream = File.Open(path, FileMode.Open))
            {
                fileStream.Seek(0, SeekOrigin.End);
                fileStream.Write(result, 0, result.Length);
            }
        }

        public void Load(string path, TextBoxBase into)
        {
            into.Clear();
            using (var fileStream = new StreamReader(path, Encoding.Default, true))
            {
                string value = fileStream.ReadToEnd();
                into.Text = value;
            }
        }
    }
}