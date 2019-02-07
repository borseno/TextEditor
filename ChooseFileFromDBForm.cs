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
        private bool _isSelected = false;

        public string SelectedFileName
        {
            get
            {
                if (_isSelected)
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
        }

        private void OnSelected(object sender, EventArgs e)
        {
            if (filesDBdataGridView.SelectedCells.Count == 1)
                _isSelected = true;
            else
                MessageBox.Show(@"You can choose only one cell");
        }
    }
}
