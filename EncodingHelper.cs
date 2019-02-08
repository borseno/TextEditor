using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace BorsenoTextEditor
{
    static class EncodingHelper
    {
        public static Encoding GetDBEncoding(string connectionString)
        {
            string query = "Pragma encoding";
            string queryResult = null;

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        queryResult = (string) reader[0];
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
        public static Encoding GetFileEncoding(string filename)
        {
            if (File.Exists(filename))
            {
                using (var fileStream = new StreamReader(filename, Encoding.Default, true))
                {
                    return fileStream.CurrentEncoding;
                }
            }
            return null;
        }
    }
}
