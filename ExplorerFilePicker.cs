using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsenoTextEditor
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

        public string GetFile()
        {
            DialogResult dialogResult = _open.ShowDialog();

            if (dialogResult == DialogResult.OK)
                return _open.FileName;
            return null;
        }

        public string GetOrCreateFile()
        {
            DialogResult dialogResult = _save.ShowDialog();

            if (dialogResult == DialogResult.OK)
                return _save.FileName;
            return null;
        }

    }
}
