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
    public partial class Form1 : Form
    {
        private string _currentFilePath;

        public Form1()
        {
            InitializeComponent();
            Save.Enabled = true;
            openFileDialog1.DefaultExt = "txt";
        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void OnFileChoosing(object sender, EventArgs e)
        {
            ChooseFile();

            if (!String.IsNullOrEmpty(_currentFilePath))
                FileManager.Load(_currentFilePath, Input);
        }

        private void OnSaving(object sender, EventArgs e)
        {
            while (String.IsNullOrEmpty(_currentFilePath))
                ChooseOrCreateFile();

            FileManager.Save(_currentFilePath, Input.Text);
        }

        private void OnClearing(object sender, EventArgs e)
        {
            Input.Clear();
        }

        private void ChooseFile()
        {
            DialogResult dialogResult = openFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _currentFilePath = openFileDialog1.FileName;
                CurrentFileNameValue.Text = _currentFilePath;
            }
        }

        private void ChooseOrCreateFile()
        {
            DialogResult dialogResult = saveFileDialog1.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                _currentFilePath = saveFileDialog1.FileName;
                CurrentFileNameValue.Text = _currentFilePath;
            }
        }

        private void ResetCurrentFileName(object sender, EventArgs e)
        {
            _currentFilePath = null;
            CurrentFileNameValue.Text = "";
        }
    }
}
