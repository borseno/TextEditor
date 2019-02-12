using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BorsenoTextEditor
{
    public partial class ChooseFileFromDBForm
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _nameColumnName;

        public bool IsSelected
        {
            get { return filesDBdataGridView.SelectedCells.Count > 0; }
        }

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

        private void LoadTable()
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

        private void ClearCellsSelection() => filesDBdataGridView.ClearSelection();

        private void OnLoad(object sender, EventArgs e)
        {
            LoadTable();
        }

        // Adds index for the table (new index, not from database)
        private void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(filesDBdataGridView.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void OnShown(object sender, EventArgs e)
        {
            ClearCellsSelection();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (IsSelected)
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $"delete from {_tableName} where {_nameColumnName} = '{SelectedFileName}'";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                LoadTable();
                ClearCellsSelection();
            }
        }

        private void ChooseFileFromDBForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                e.Handled = true;
                Delete.PerformClick();
            }
            else if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                Cancel.PerformClick();
            }
            else if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                SelectButton.PerformClick();
            }
        }
    }
}
