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
    public partial class ChooseOrCreateFileFromDBForm : Form
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _nameColumnName;

        public bool IsSelected { get; private set; } = false;

        public string SelectedFileName
        {
            get
            {
                //if (IsSelected)
                   // return filesDBdataGridView.SelectedCells[0].Value.ToString();
                return null;
            }
        }

        public ChooseOrCreateFileFromDBForm()
        {
            InitializeComponent();
        }

        private void FilesDBDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
    }
}
