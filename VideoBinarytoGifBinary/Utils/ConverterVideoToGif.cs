using FFmpeg.NET;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class ConverterVideoToGif
    {
        public static async Task<string> Converter(string filePath)
        {
            var splitFile = filePath.Split(".");
            var outputFilePath = splitFile[0] + splitFile[1].Replace(splitFile[1], ".gif");

            var inputVideo = new MediaFile(filePath); // arquivo origem
            var outputGif = new MediaFile(outputFilePath);

            var ffmpeg = new Engine(@"D:\ffmpeg\bin\ffmpeg.exe");

            await ffmpeg.ConvertAsync(inputVideo, outputGif);

            return outputFilePath;
        }
    }
}
