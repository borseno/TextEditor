using System.Windows.Forms;
using BorsenoTextEditor.File_Work.Interfaces;
using BorsenoTextEditor.Forms;

namespace BorsenoTextEditor.File_Work.Implementors.Database
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

        public string GetFileName()
        {
            _chooseForm.ShowDialog();

            if (_chooseForm.DialogResult == DialogResult.OK)
                return _chooseForm.SelectedFileName;  
            
            return null;
        }

        public string GetOrCreateFileName()
        {
            _saveAsForm.ShowDialog();

            if (_saveAsForm.DialogResult == DialogResult.OK)
                return _saveAsForm.FileName;

            return null;
        }
    }
}
