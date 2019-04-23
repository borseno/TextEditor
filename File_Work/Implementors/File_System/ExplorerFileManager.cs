using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorsenoTextEditor.File_Work.Helper_Classes;
using BorsenoTextEditor.File_Work.Interfaces;

namespace BorsenoTextEditor.File_Work.Implementors.File_System
{
    sealed class ExplorerFileManager : IFileManager
    {
        public async Task Save(string path, string value)
        {
            Encoding fileEncoding = await EncodingHelper.GetFileEncoding(path) ?? Encoding.Default;

            var result = await Task.Run( () => fileEncoding.GetBytes(value) );

            using (var fileStream = await Task.Run( () => File.Open(path, System.IO.FileMode.Create) ))
            {                             
                fileStream.Seek(0, SeekOrigin.End);
                await fileStream.WriteAsync(result, 0, result.Length);
            }
        }

        public async Task Load(string path, TextBoxBase into)
        {
            into.Clear();

            using (var fileStream = await Task.Run( () => new StreamReader(path, true) ))
            {
                string value = await fileStream.ReadToEndAsync();
                into.Text = value;
            }
        }
    }
}