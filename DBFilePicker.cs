using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorsenoTextEditor
{
    sealed class DBFilePicker : IFilePicker
    {
        private readonly ChooseFileFromDBForm _chooseForm;
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _valueColumnName;
        private readonly string _nameColumnName;

        public DBFilePicker
            (string connectionString, string tableName,
            string valueColumnName, string nameColumnName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _valueColumnName = valueColumnName;
            _nameColumnName = nameColumnName;

            _chooseForm = new ChooseFileFromDBForm(_connectionString, _tableName, _nameColumnName);
        }

        public string GetFile()
        {
            _chooseForm.ShowDialog();
            if (_chooseForm.DialogResult == DialogResult.OK)
                return _chooseForm.SelectedFileName;
            else
                return null;
        }

        public string GetOrCreateFile()
        {
            throw new NotImplementedException();
        }
    }
}
