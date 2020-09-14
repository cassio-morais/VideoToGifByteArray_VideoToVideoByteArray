using System;
using System.Threading.Tasks;
using VideoBinarytoGifBinary.Models;

namespace VideoBinarytoGifBinary.Utils
{
    public class ConverterToViewFormat
    {
        private readonly DescompressByteArray _descompressByteArray;

        public ConverterToViewFormat(DescompressByteArray descompressByteArray)
        {
            _descompressByteArray = descompressByteArray;
        }

        public async Task<Video> Converter(VideoByteArray file)
        {

            var descompressVideoByteArray = await _descompressByteArray.Descompress(file);
            var vid = new Video { Id = file.Id, VideoBase64 = Convert.ToBase64String(descompressVideoByteArray.VideoByte) };

            return vid;

        }
    }
}
