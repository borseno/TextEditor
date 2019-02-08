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
    public partial class SaveAsForm : Form
    {
        bool _isOKPressed = false;

        public string FileName
        {
            get
            {
                if (_isOKPressed && !String.IsNullOrEmpty(input.Text))
                    return input.Text;
                return null;
            }
        }

        public SaveAsForm()
        {
            InitializeComponent();
        }

        private void OnOk(object sender, EventArgs e)
        {
            _isOKPressed = true;
        }
    }
}
