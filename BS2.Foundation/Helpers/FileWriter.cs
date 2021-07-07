using System.IO;
using System.Threading.Tasks;

namespace BS2.Foundation.Helpers
{
    public static class FileWriter
    {
        public static async Task WriteAndFlushAsync(byte[] content, string path)
        {
            using var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            await fs.WriteAsync(content, 0, content.Length);
            await fs.FlushAsync();
        }

        public static void WriteAndFlushToDisk(string content, string path)
        {
            using var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (var writer = new StreamWriter(fs))
            {
                writer.Write(content);
                fs.Flush(true);
            }

            fs.Close();
        }
    }
}