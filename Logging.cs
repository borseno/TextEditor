using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BorsenoTextEditor
{
    static class Logging
    {
        public static async Task Log(Exception e)
        {
            await Task.Run(async () =>
            {
                using (var stream = File.OpenWrite("Logs.txt"))
                {
                    var nl = Environment.NewLine;
                    var msg = $"Message:{nl}{e.Message}{nl}" +
                              $"InnerException:{nl}{e.InnerException}{nl}" +
                              $"Method:{nl}{e.TargetSite.Name}{nl}" +
                              $"StackTrace:{nl}----------------------{nl}" +
                              $"{e.StackTrace}" +
                              $"{nl}";

                    var buffer = Encoding.UTF8.GetBytes(msg);

                    stream.Seek(0, SeekOrigin.End);
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                }
            });
        }
    }
}
