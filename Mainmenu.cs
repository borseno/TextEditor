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
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace BorsenoTextEditor
{
    public partial class MainForm : Form
    {
        private object _locker = new object();
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
            set => CurrentFileNameValue.Text = _currentFileName = value;
        }

        private string CurrentFileExtension => CurrentFilePath != null ? new FileInfo(CurrentFilePath).Extension : null;

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

        private void ResetTextBoxColors()
        {
            Input.BeginUpdate();

            Input.ForeColor = Color.Black;

            int selectionStart = Input.SelectionStart;
            int selectionLength = Input.SelectionLength;

            Input.SelectAll();
            Input.SelectionColor = Color.Black;
            Input.DeselectAll();

            Input.SelectionStart = selectionStart;
            Input.SelectionLength = selectionLength;

            Input.EndUpdate();
        }

        private void OnFileChoosing(object sender, EventArgs e)
        {
            OpenFile();

            if (!String.IsNullOrEmpty(CurrentFilePath))
            {
                ResetTextBoxColors();
                _fileManager.Load(CurrentFilePath, Input);
            }
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

        private void HighlightSyntax(string syntax)
        {
            Regex regex = null;

            switch (syntax)
            {
                case ".xml":
                    regex = new Regex(@"<\/?[^>\/]*>");
                    break;
            }

            if (regex != null)
            {
                ResetTextBoxColors();

                Input.BeginUpdate();

                int lastIndex = Input.SelectionStart;
                int lastLength = Input.SelectionLength;

                Input.SelectAll();

                var matches = regex.Matches(Input.Text).Cast<Match>().ToArray();
                if (matches.Length > 0)
                {
                    Color color = Color.ForestGreen;
                    int start = 0;
                    int end = matches.Length - 1;

                    SelectMatchesFromArr(matches, start, end, color);
                }

                Input.Select(lastIndex, lastLength);
                Input.SelectionColor = Color.Black;

                Input.EndUpdate();
            }
        }

        private void SelectMatchesFromArr(Match[] matches, int startIndex, int endIndex, Color color)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                int selectionStart = Input.SelectionStart;

                Input.Select(matches[i].Index, matches[i].Length);
                Input.SelectionColor = color;

                Input.DeselectAll();
                Input.SelectionStart = selectionStart;
                Input.SelectionLength = 0;
            }
        }

        private void FileMode_Click(object sender, EventArgs e)
        {
            string buttonText = _fileMode + " mode";
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

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (CurrentFileExtension.In(".json", ".xml"))
            {
                HighlightSyntax(CurrentFileExtension);
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentFileExtension.In(".json", ".xml"))
                if (e.KeyData == (Keys.Control | Keys.Z))
                    e.Handled = true;
        }
    }
}
