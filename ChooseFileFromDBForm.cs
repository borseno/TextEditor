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
    public partial class ChooseFileFromDBForm
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _nameColumnName;

        public bool IsSelected { get; private set; } = false;

        public string SelectedFileName
        {
            get
            {
                if (IsSelected)
                    return filesDBdataGridView.SelectedCells[0].Value.ToString();
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
            IsSelected = true;
        }
        private void filesDBdataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(filesDBdataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
    }
}
