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
        private string _name;

        public DBFilePicker
            (ChooseFileFromDBForm chooseForm, string connectionString, string tableName,
            string valueColumnName, string nameColumnName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _valueColumnName = valueColumnName;
            _nameColumnName = nameColumnName;
        }

        public string GetFile()
        {
            // ???  I know it's a bad idea... I Tried to inherit from CommonDialog
            while (!_chooseForm.IsSelected)
                ;
            return _chooseForm.SelectedFileName;
        }

        public string GetOrCreateFile()
        {
            throw new NotImplementedException();
        }
    }
}
