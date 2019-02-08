using System.Windows.Forms;

namespace BorsenoTextEditor
{
    sealed class DBFilePicker : IFilePicker
    {
        private readonly ChooseFileFromDBForm _chooseForm;
        private readonly SaveAsForm _saveAsForm;

        public DBFilePicker
            (string connectionString, string tableName, string nameColumnName)
        {
            _chooseForm = new ChooseFileFromDBForm(connectionString, tableName, nameColumnName);
            _saveAsForm = new SaveAsForm();
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
            _saveAsForm.ShowDialog();

            if (_saveAsForm.DialogResult == DialogResult.OK)
                return _saveAsForm.FileName;
            else
                return null;
        }
    }
}
