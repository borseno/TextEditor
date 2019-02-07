using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace BorsenoTextEditor
{
    public partial class ChooseFileFromDBForm : Form
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _nameColumnName;
        private CellSelectionDialog csd = null;

        public bool IsSelected { get; private set; } = false;

        public string SelectedFileName
        {
            get
            {
                if (IsSelected)
                    return filesDBdataGridView.SelectedCells[0].ToString();
                return null;
            }
        }

        public ChooseFileFromDBForm(string connectionString, string tableName, string nameColumnName)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _tableName = tableName;
            _nameColumnName = nameColumnName;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                SQLiteDataAdapter dataAdapter =
                    new SQLiteDataAdapter($"Select {_nameColumnName} from {_tableName}", connection);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                filesDBdataGridView.DataSource = dataSet.Tables[0];
            }
            csd = new CellSelectionDialog();
            csd.FormClosing += CellSelectionDialog_FormClosing;
            csd.Show();
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (filesDBdataGridView.SelectedCells.Count == 1)
                IsSelected = true;
            else
                MessageBox.Show(@"You can choose only one cell");
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (csd != null)
            {
                csd.Cells = filesDBdataGridView.SelectedCells;
                csd.BringToFront();
            }
        }
        private void CellSelectionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (csd.DialogResult == DialogResult.OK)
            {
                //Do something with csd.cells
                MessageBox.Show(csd.Cells[0].Value.ToString());
                //set the form to null;
                csd = null;
            }
        }
    }
}
