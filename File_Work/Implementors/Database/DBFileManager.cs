using System;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BorsenoTextEditor.File_Work.Helper_Classes;
using BorsenoTextEditor.File_Work.Interfaces;

namespace BorsenoTextEditor.File_Work.Implementors.Database
{
    sealed class DBFileManager : IFileManager
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly string _valueColumnName;
        private readonly string _nameColumnName;
        private readonly Encoding _valueEncoding;

        public DBFileManager(string connectionString, string tableName, string valueColumnName, string nameColumnName)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _valueColumnName = valueColumnName;
            _nameColumnName = nameColumnName;
            _valueEncoding = EncodingHelper.GetDBEncodingSync(connectionString);
        }

        public async Task Save(string name, string value)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                string query = $"Select id from {_tableName} where {_nameColumnName} = @name";
                bool nameExists;

                await conn.OpenAsync();

                using (var checkCMD = new SQLiteCommand(query, conn)) // get whether name exists or not
                {
                    checkCMD.Parameters.Add(new SQLiteParameter("@name", name));
                    using (var reader = await checkCMD.ExecuteReaderAsync())
                    {
                        nameExists = reader.HasRows;
                    }
                }

                using (var saveCMD = new SQLiteCommand(conn))
                {
                    if (nameExists)
                    {
                        saveCMD.CommandText = $"Update {_tableName} " +
                                $"set {_valueColumnName} = @value " +
                                $"where {_nameColumnName} = @name";
                    }
                    else
                    {
                        saveCMD.CommandText = $"Insert into {_tableName}({_valueColumnName}, {_nameColumnName}) " +
                                $"values (@value, @name)";
                    }

                    saveCMD.Parameters.Add(new SQLiteParameter("@value", value));
                    saveCMD.Parameters.Add(new SQLiteParameter("@name", name));

                    await saveCMD.ExecuteNonQueryAsync();
                }
            }

        }

        public async Task Load(string name, TextBoxBase textBox)
        {
            StringBuilder value = new StringBuilder(32);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = $"SELECT distinct {_valueColumnName} " +
                               $"from {_tableName} " +
                               $"where {_nameColumnName} = @name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@name", name));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        textBox.Text = "";

                        if (reader.HasRows)
                        {                           
                            while (reader.Read())
                            {                              
                                string temp = await Task.Run( () => _valueEncoding.GetString((byte[])reader[_valueColumnName]));
                                textBox.Text += temp;
                            }
                        }
                    }
                }
            }  
        }
    }
}
