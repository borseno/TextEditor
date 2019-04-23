using System.Windows.Forms;
using BorsenoTextEditor.File_Work.Interfaces;

namespace BorsenoTextEditor.File_Work.Implementors.File_System
{
    sealed class ExplorerFilePicker : IFilePicker
    {
        private readonly SaveFileDialog _save;
        private readonly OpenFileDialog _open;

        public ExplorerFilePicker(SaveFileDialog save, OpenFileDialog open)
        {
            _save = save;
            _open = open;
        }

        public string GetFileName()
        {
            DialogResult dialogResult = _open.ShowDialog();

            if (dialogResult == DialogResult.OK)
                return _open.FileName;

            return null;
        }

        public string GetOrCreateFileName()
        {
            DialogResult dialogResult = _save.ShowDialog();

            if (dialogResult == DialogResult.OK)
                return _save.FileName;

            return null;
        }

    }
}
