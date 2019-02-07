using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsenoTextEditor
{
    interface ITextFileManager
    {
        void Save(string filename, string data);
        void Load(string filename, TextBoxBase textBox);
    }
}
