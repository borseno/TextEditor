using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorsenoTextEditor.Extensions;
using BorsenoTextEditor.File_Work.Implementors.Database;
using BorsenoTextEditor.File_Work.Implementors.File_System;
using BorsenoTextEditor.File_Work.Interfaces;
using BorsenoTextEditor.TextProcessors;
using FileMode = BorsenoTextEditor.File_Work.Helper_Classes.FileMode;

namespace BorsenoTextEditor.Forms
{
    public partial class MainForm : Form
    {
        private const string TableName = "binary_Files";
        private const string ValueColumnName = "binary_file";
        private const string NameColumnName = "Name";

        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly Color _defaultTextColor = Color.Black;
        private readonly Color _syntaxHighlightingTextColor = Color.ForestGreen;
        private readonly HighlightSupportRichTextBoxColorsProcessor _highlightingProcessor;

        private string _currentFileName;
        private FileMode? _fileMode;
        private bool _darkEnabled;

        private IFilePicker _filePicker;
        private IFileManager _fileManager;

        private string CurrentFileName
        {
            get => _currentFileName;
            set => CurrentFileNameValue.Text = _currentFileName = value;
        }

        private string CurrentFileExtension => CurrentFileName != null ? new FileInfo(CurrentFileName).Extension : null;

        public MainForm()
        {
            InitializeComponent();

            openFileDialog1.DefaultExt = "txt";
            saveFileDialog1.DefaultExt = "txt";

            _highlightingProcessor = new HighlightSupportRichTextBoxColorsProcessor(Input, _defaultTextColor);

            ChangeFileModeSync(File_Work.Helper_Classes.FileMode.Database);
        }

        private async Task SaveText()
        {
            if (!String.IsNullOrEmpty(CurrentFileName))
                await _fileManager.Save(CurrentFileName, Input.Text);
            else
            {
                OpenOrCreateFile();

                if (!String.IsNullOrEmpty(CurrentFileName))
                    await _fileManager.Save(CurrentFileName, Input.Text);
            }
        }

        private async Task ChangeFileMode(FileMode mode)
        {
            await Task.Run(() =>
            {
                if (_fileMode == mode)
                    return;

                if (mode == File_Work.Helper_Classes.FileMode.Database)
                {
                    _fileManager = new DBFileManager(_connectionString, TableName, ValueColumnName, NameColumnName);
                    _filePicker = new DBFilePicker(_connectionString, TableName, NameColumnName);
                }
                else if (mode == File_Work.Helper_Classes.FileMode.Explorer)
                {
                    _fileManager = new ExplorerFileManager();
                    _filePicker = new ExplorerFilePicker(save: saveFileDialog1, open: openFileDialog1);
                }

                _fileMode = mode;
            });
        }

        private void ChangeFileModeSync(FileMode mode) // used in constructor
        {
            if (_fileMode == mode)
                return;

            if (mode == File_Work.Helper_Classes.FileMode.Database)
            {
                _fileManager = new DBFileManager(_connectionString, TableName, ValueColumnName, NameColumnName);
                _filePicker = new DBFilePicker(_connectionString, TableName, NameColumnName);
            }
            else if (mode == File_Work.Helper_Classes.FileMode.Explorer)
            {
                _fileManager = new ExplorerFileManager();
                _filePicker = new ExplorerFilePicker(save: saveFileDialog1, open: openFileDialog1);
            }

            _fileMode = mode;
        }

        private void GetFileName()
        {
            string filename = _filePicker.GetFileName();

            if (filename != null)
                CurrentFileName = filename;
        }

        private void OpenOrCreateFile()
        {
            string filename = _filePicker.GetOrCreateFileName();

            if (filename != null)
                CurrentFileName = filename;
        }

        private void ResetCurrentFileName(object sender, EventArgs e)
        {
            CurrentFileName = null;
        }

        #region event handlers

        private async void InputPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
                e.IsInputKey = true;
            if (e.KeyData == (Keys.Tab | Keys.Shift))
                e.IsInputKey = true;
            if (e.KeyData == (Keys.Control | Keys.S))
                await SaveText();
        }

        private async void OnFileChoosing(object sender, EventArgs e)
        {
            GetFileName();

            if (!String.IsNullOrEmpty(CurrentFileName))
            {
                _highlightingProcessor.ResetTextBoxColors();
                await _fileManager.Load(CurrentFileName, Input);
            }
        }

        private async void OnSaving(object sender, EventArgs e)
        {
            await SaveText();
        }

        private void OnClearing(object sender, EventArgs e)
        {
            Input.Clear();
        }

        private async void FileMode_Click(object sender, EventArgs e)
        {
            string buttonText = _fileMode + " mode";
            FileMode.Text = buttonText;

            if (_fileMode == File_Work.Helper_Classes.FileMode.Database)
            {
                await ChangeFileMode(File_Work.Helper_Classes.FileMode.Explorer);
            }
            else if (_fileMode == File_Work.Helper_Classes.FileMode.Explorer)
            {
                await ChangeFileMode(File_Work.Helper_Classes.FileMode.Database);
            }
            CurrentFileName = null;
        }

        private void ScreenMode_Click(object sender, EventArgs e)
        {
            this.ScreenMode.Text = this.BackColor.Name + @" mode";

            if (_darkEnabled == false)
            {
                this.BackColor = Color.Black;
                this.CurrentFileNameLabel.ForeColor = Color.DarkGreen;
                _darkEnabled = true;
            }
            else
            {
                this.BackColor = Color.White;
                _darkEnabled = false;
            }
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (CurrentFileExtension.In(".xml"))
            {
                Regex regex = null;

                switch (CurrentFileExtension)
                {
                    case ".xml":
                        regex = new Regex(@"<\/?[^>\/]*>");
                        break;
                }

                if (regex != null)
                {
                    _highlightingProcessor.HighlightSyntax(regex, _syntaxHighlightingTextColor);
                }
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentFileExtension.In(".xml"))
                if (e.KeyData == (Keys.Control | Keys.Z))
                    e.Handled = true;
        }

        #endregion
    }
}
