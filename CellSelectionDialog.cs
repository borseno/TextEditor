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
    public partial class CellSelectionDialog : Form
    {
        public DataGridViewSelectedCellCollection Cells { get; set; }
        public CellSelectionDialog()
        {
            InitializeComponent();
        }
    }
}
