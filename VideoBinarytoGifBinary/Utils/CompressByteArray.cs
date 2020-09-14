using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class CompressByteArray
    {
        public async Task<byte[]> Compress(byte[] byteFile)
        {
            using MemoryStream CompressedByteFile = new MemoryStream();
            {
                using GZipStream ds = new GZipStream(CompressedByteFile, CompressionLevel.Optimal);
                {
                    await ds.WriteAsync(byteFile, 0, byteFile.Length);

                }
                return CompressedByteFile.ToArray();
            }
        }
    }
}
