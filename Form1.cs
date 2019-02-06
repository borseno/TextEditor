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
        public Form1()
        {
            InitializeComponent();
        }

        private void onKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void WriteToNewFile0OnClick(object sender, EventArgs e)
        {
            FileManager.Save(@"C:\Users\VAIO\source\repos\BorsenoTextEditor\NewFile0.txt", Input.Text);
        }

        private void ReadFromNewFile1OnClick(object sender, EventArgs e)
        {
            FileManager.Load(@"C:\Users\VAIO\source\repos\BorsenoTextEditor\NewFile1.txt", Input);
        }
    }
}
