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
            _chooseForm.FormClosed += OnFormClosed;
            _chooseForm.Show();



            throw new NotImplementedException();
        }

        public string GetOrCreateFile()
        {
            throw new NotImplementedException();
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            _name = ((ChooseFileFromDBForm) sender).SelectedFileName;
            GetFile();
        }
    }
}
