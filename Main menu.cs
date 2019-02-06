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
        }

        private void SaveText()
        {
            if (!String.IsNullOrEmpty(CurrentFilePath))
                FileManager.Save(CurrentFilePath, Input.Text);
            else
            {
                ChooseOrCreateFile();

                if (!String.IsNullOrEmpty(CurrentFilePath))
                    FileManager.Save(CurrentFilePath, Input.Text);
            }
        }

        private void ChooseFile()
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
                CurrentFilePath = openFileDialog1.FileName;
        }

        private void ChooseOrCreateFile()
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
                CurrentFilePath = saveFileDialog1.FileName;
        }

        private void OnFileChoosing(object sender, EventArgs e)
        {
            ChooseFile();

            if (!String.IsNullOrEmpty(CurrentFilePath))
                FileManager.Load(CurrentFilePath, Input);
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
            {
                SaveText();
            }
        }
    }
}
