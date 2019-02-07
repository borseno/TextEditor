using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsenoTextEditor
{
    public partial class MainForm : Form
    {
        private readonly IFilePicker _filePicker;
        private readonly ITextFileManager _fileManager;
        private string _currentFilePath;

        private string CurrentFilePath
        {
            get => _currentFilePath;
            set => _currentFilePath = CurrentFileNameValue.Text = value;
        }

        public MainForm()
        {
            InitializeComponent();

            openFileDialog1.DefaultExt = "txt";
            saveFileDialog1.DefaultExt = "txt";

            _fileManager = new ExplorerFileManager();
            _filePicker = new ExplorerFilePicker(save: saveFileDialog1, open: openFileDialog1);
        }

        private void SaveText()
        {
            if (!String.IsNullOrEmpty(CurrentFilePath))
                _fileManager.Save(CurrentFilePath, Input.Text);
            else
            {
                OpenOrCreateFile();

                if (!String.IsNullOrEmpty(CurrentFilePath))
                    _fileManager.Save(CurrentFilePath, Input.Text);
            }
        }

        private void OpenFile()
        {
            string filename = _filePicker.GetFile();

            if (filename != null)
                CurrentFilePath = filename;
        }

        private void OpenOrCreateFile()
        {
            string filename = _filePicker.GetOrCreateFile();

            if (filename != null)
                CurrentFilePath = filename;
        }

        private void OnFileChoosing(object sender, EventArgs e)
        {
            OpenFile();

            if (!String.IsNullOrEmpty(CurrentFilePath))
                _fileManager.Load(CurrentFilePath, Input);
        }

        private void OnSaving(object sender, EventArgs e)
        {
            SaveText();
        }

        private void OnClearing(object sender, EventArgs e)
        {
            Input.Clear();
        }

        private void ResetCurrentFileName(object sender, EventArgs e)
        {
            CurrentFilePath = null;
        }

        private void InputPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                e.IsInputKey = true;
            if (e.KeyData == (Keys.Tab | Keys.Shift))
                e.IsInputKey = true;
            if (e.KeyData == (Keys.Control | Keys.S))
                SaveText();
        }
    }
}
