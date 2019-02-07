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

        public DBFileManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(string name, string value)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                string tablename = "binary_Files";

                bool nameExists;
                using (var checkCMD = new SQLiteCommand(
                    $"Select id from {tablename} where Name = '{name}'", conn))
                {
                    nameExists = checkCMD.ExecuteReader().HasRows;
                }

                string query;
                if (nameExists)
                {
                    query = $"Update {tablename} " +
                                   $"set binary_file = '{value}' " +
                                   $"where Name = '{name}'";
                }
                else
                {
                    query = $"Insert into {tablename}(binary_file, Name) " +
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

                string tableName = "binary_Files";

                string query = $"SELECT distinct binary_file from {tableName} " +
                               $"where Name = '{name}'";

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
