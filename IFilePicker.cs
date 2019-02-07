using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorsenoTextEditor
{
    interface IFilePicker
    {
        string GetFile();
        string GetOrCreateFile();
    }
}
