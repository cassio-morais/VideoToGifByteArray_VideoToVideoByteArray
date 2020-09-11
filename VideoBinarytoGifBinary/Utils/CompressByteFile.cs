using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class CompressByteFile
    {
        public static async Task<byte[]> Compress(byte[] byteFile)
        {
            var CompressedByteFile = new MemoryStream();
            using var ds = new DeflateStream(CompressedByteFile, CompressionLevel.Optimal);
            await ds.WriteAsync(byteFile, 0, byteFile.Length);
            return CompressedByteFile.ToArray();
        }
    }
}
