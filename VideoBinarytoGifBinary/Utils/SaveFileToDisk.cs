using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class SaveFileToDisk
    {
        public static async Task<string> Save(IFormFile file)
        {
            var origin = Path.Combine(Path.GetTempPath(), "uploads");
            var filePath = Path.Combine(origin, file.FileName);
            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);

            return filePath;
        }
    }
}
