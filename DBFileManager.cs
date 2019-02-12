using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BorsenoTextEditor
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
            _valueEncoding = EncodingHelper.GetDBEncoding(connectionString);
        }

        public void Save(string name, string value)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();

                string query = $"Select id from {_tableName} where {_nameColumnName} = @name";

                bool nameExists;
                using (var checkCMD = new SQLiteCommand(query, conn)) // get whether name exists or not
                {
                    checkCMD.Parameters.Add(new SQLiteParameter("@name", name));
                    using (var reader = checkCMD.ExecuteReader())
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

                    saveCMD.ExecuteNonQuery();
                }
            }
        }

        public void Load(string name, TextBoxBase textBox)
        {
            StringBuilder value = new StringBuilder(32);

            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                string query = $"SELECT distinct {_valueColumnName} " +
                               $"from {_tableName} " +
                               $"where {_nameColumnName} = @name";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@name", name));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string temp = _valueEncoding.GetString((byte[]) reader[_valueColumnName]);
                                value.AppendLine(temp);
                            }
                        }
                    }
                }
            }
            textBox.Text = value.ToString();
        }
    }
}
