using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BorsenoTextEditor
{
    class DBFileManager : ITextFileManager
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _valueColumnName;
        private readonly string _nameColumnName;

        public DBFileManager(string connectionString, string tableName, string valueColumnName, string nameColumnName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _valueColumnName = valueColumnName;
            _nameColumnName = nameColumnName;
        }

        public void Save(string name, string value)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                bool nameExists;
                using (var checkCMD = new SQLiteCommand(
                    $"Select id from {_tableName} where {_nameColumnName} = '{name}'", conn))
                {
                    nameExists = checkCMD.ExecuteReader().HasRows;
                }

                string query;
                if (nameExists)
                {
                    query = $"Update {_tableName} " +
                                   $"set {_valueColumnName} = '{value}' " +
                                   $"where {_nameColumnName} = '{name}'";
                }
                else
                {
                    query = $"Insert into {_tableName}({_valueColumnName}, {_nameColumnName}) " +
                            $"values ('{value}', '{name}')";
                }

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Load(string name, TextBoxBase textBox)
        {
            string value = null;

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = $"SELECT distinct {_valueColumnName} from {_tableName} " +
                               $"where {_nameColumnName} = '{name}'";

                using (var command = new SQLiteCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        value = reader.GetTextReader(0).ReadToEnd();
                    }
                }
            }
            textBox.Text = value;
        }
    }
}
