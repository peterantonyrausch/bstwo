using System.Collections.Generic;
using System.Linq;

namespace BS2.Foundation.Helpers
{
    public static class MimeTypeFactory
    {
        public static string MakeFormat(string mimeType)
        {
            if (string.IsNullOrEmpty(mimeType))
            {
                throw new System.Exception("Extensão do arquivo não foi encontrada.");
            }

            var types = GetMimeTypes();

            return types.First(x => x.Value == mimeType).Key;
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}