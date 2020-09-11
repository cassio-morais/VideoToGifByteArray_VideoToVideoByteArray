using System.IO;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class GifToByteArray
    {
        public static async Task<byte[]> LoadGifFileFromDiskandReturnAByteArray(string gifPath)
        {
            using var st = File.Open(gifPath, FileMode.Open);

            using var ms = new MemoryStream();
            await st.CopyToAsync(ms);
            var fileFormatToBytes = ms.ToArray();

            return fileFormatToBytes;

        }
    }
}
