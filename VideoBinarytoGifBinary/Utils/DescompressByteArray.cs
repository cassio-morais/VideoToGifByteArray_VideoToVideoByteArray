using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using VideoBinarytoGifBinary.Models;

namespace VideoBinarytoGifBinary.Utils
{
    public class DescompressByteArray
    {
        public async Task<VideoByteArray> Descompress(VideoByteArray file)
        {

            MemoryStream input = new MemoryStream(file.VideoByte);
            MemoryStream output = new MemoryStream();
            using GZipStream gz = new GZipStream(input, CompressionMode.Decompress);
            {
                await gz.CopyToAsync(output);
            };

            file.VideoByte = output.ToArray();

            return file;
        }
    }
}
