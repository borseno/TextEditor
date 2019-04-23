using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsenoTextEditor.File_Work.Interfaces
{
    interface IFileManager
    {
        Task Save(string filename, string data);
        Task Load(string filename, TextBoxBase textBox);
    }
}
