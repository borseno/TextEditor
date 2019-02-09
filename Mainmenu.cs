using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BorsenoTextEditor
{
    public partial class MainForm : Form
    {
        private readonly string _tableName = "binary_Files";
        private readonly string _valueColumnName = "binary_file";
        private readonly string _nameColumnName = "Name";
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private string _currentFileName;
        private IFilePicker _filePicker;
        private IFileManager _fileManager;
        private FileMode? _fileMode = null;
        bool _darkEnabled;

        private string CurrentFilePath
        {
            get => _currentFileName;
            set => _currentFileName = CurrentFileNameValue.Text = value;
        }

        public MainForm()
        {
            InitializeComponent();

            openFileDialog1.DefaultExt = "txt";
            saveFileDialog1.DefaultExt = "txt";

            ChangeFileMode(BorsenoTextEditor.FileMode.Database);
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

        private void ChangeFileMode(FileMode mode)
        {
            if (_fileMode == mode)
                return;

            if (mode == BorsenoTextEditor.FileMode.Database)
            {
                _fileManager = new DBFileManager(_connectionString, _tableName, _valueColumnName, _nameColumnName);
                _filePicker = new DBFilePicker(_connectionString, _tableName, _nameColumnName);
            }
            else if (mode == BorsenoTextEditor.FileMode.Explorer)
            {
                _fileManager = new ExplorerFileManager();
                _filePicker = new ExplorerFilePicker(save: saveFileDialog1, open: openFileDialog1);
            }
            _fileMode = mode;
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

        private void FileMode_Click(object sender, EventArgs e)
        {
            string buttonText = _fileMode.ToString() + " mode";
            FileMode.Text = buttonText;

            if (_fileMode == BorsenoTextEditor.FileMode.Database)
            {
                ChangeFileMode(BorsenoTextEditor.FileMode.Explorer);
            }
            else if (_fileMode == BorsenoTextEditor.FileMode.Explorer)
            {
                ChangeFileMode(BorsenoTextEditor.FileMode.Database);
            }
            CurrentFilePath = null;
        }

        private void ScreenMode_Click(object sender, EventArgs e)
        {
            this.ScreenMode.Text = this.BackColor.Name + " mode";

            if (_darkEnabled == false)
            {
                this.BackColor = System.Drawing.Color.Black;
                this.CurrentFileNameLabel.ForeColor = System.Drawing.Color.DarkGreen;
                _darkEnabled = true;
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                _darkEnabled = false;
                
            }
        }
    }
}
