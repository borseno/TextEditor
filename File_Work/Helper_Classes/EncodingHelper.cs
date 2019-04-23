using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BorsenoTextEditor.File_Work.Helper_Classes
{
    static class EncodingHelper
    {
        public static async Task<Encoding> GetDBEncoding(string connectionString)
        {
            const string query = "Pragma encoding";
            string queryResult = null;

            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            await reader.ReadAsync();
                            queryResult = (string)reader[0];
                        }
                    }
                }
            }

            switch (queryResult)
            {
                case "UTF-8":
                    return Encoding.UTF8;
                case "UTF-7":
                    return Encoding.UTF7;
                case "UTF-32":
                    return Encoding.UTF32;
                case "ASCII":
                    return Encoding.ASCII;
                case "Unicode":
                    return Encoding.Unicode;
                default:
                    return Encoding.Default;
            }
        }

        public static async Task<Encoding> GetFileEncoding(string filename)
        {
            if (await Task.Run( () => File.Exists(filename) ))
            {
                using (var fileStream = await Task.Run( () => new StreamReader(filename, true) ))
                {
                    return fileStream.CurrentEncoding;
                }
            }
            return null;
        }

        public static Encoding GetDBEncodingSync(string connectionString)
        {
            const string query = "Pragma encoding";
            string queryResult = null;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.ReadAsync();
                            queryResult = (string)reader[0];
                        }
                    }
                }
            }

            switch (queryResult)
            {
                case "UTF-8":
                    return Encoding.UTF8;
                case "UTF-7":
                    return Encoding.UTF7;
                case "UTF-32":
                    return Encoding.UTF32;
                case "ASCII":
                    return Encoding.ASCII;
                case "Unicode":
                    return Encoding.Unicode;
                default:
                    return Encoding.Default;
            }
        } // used in constructors
    }
}
