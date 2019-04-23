using System;
using System.Windows.Forms;

namespace BorsenoTextEditor.Forms
{
    public partial class SaveAsForm : Form
    {
        public string FileName
        {
            get
            {
                if (!String.IsNullOrEmpty(input.Text))
                    return input.Text;
                return null;
            }
        }

        public SaveAsForm()
        {
            InitializeComponent();
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                Cancel.PerformClick();
            }
            else if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                OK.PerformClick();
            }
        }
    }
}
