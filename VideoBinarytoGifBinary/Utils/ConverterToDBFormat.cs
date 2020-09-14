using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class ConverterToDBFormat
    {
        private readonly VideoToByteArray _videoToByteArray;
        private readonly CompressByteArray _compressByteArray;


        public ConverterToDBFormat(VideoToByteArray videoToByteArray, CompressByteArray compressByteFile)
        {
            _videoToByteArray = videoToByteArray;
            _compressByteArray = compressByteFile;
        }


        public async Task<byte[]> Converter(IFormFile file)
        {
            var byteArray = await _videoToByteArray.Converter(file);

            var byteArrayCompressed = await _compressByteArray.Compress(byteArray);

            return byteArrayCompressed;

        }
    }
}
