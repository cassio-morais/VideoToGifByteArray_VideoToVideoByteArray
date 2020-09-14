using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class VideoToByteArray
    {
        public async Task<byte[]> Converter(IFormFile file)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var fileFormatToBytes = ms.ToArray();

            return fileFormatToBytes;
        }
    }
}
