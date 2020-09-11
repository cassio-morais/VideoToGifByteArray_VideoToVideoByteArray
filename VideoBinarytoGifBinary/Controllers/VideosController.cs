using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoBinarytoGifBinary.Data.Entity;
using VideoBinarytoGifBinary.Models;
using VideoBinarytoGifBinary.Utils;

namespace VideoBinarytoGifBinary.Controllers
{
    public class VideosController : Controller
    {
        private readonly Context _context;

        public VideosController(Context context){
            _context = context;
        }
             

        public IActionResult Index()
        {
         
            
            

            return View();
        }


        public IActionResult VideoToVideo()
        {

            return View();
        }

        public IActionResult VideoToGif()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VideoToGif(IFormFile file)
        {

            Console.WriteLine("Arquivo de vídeo recebido: " + file.Length);

            var filePath = await SaveFileToDisk.Save(file);

            var gifPath = await ConverterVideoToGif.Converter(filePath);

            var gifFileByteArray = await  GifToByteArray.LoadGifFileFromDiskandReturnAByteArray(gifPath);
                           
            var gifFileByteArrayCompressed = await CompressByteFile.Compress(gifFileByteArray);

            Console.WriteLine("gif byte array comprimido: " + gifFileByteArrayCompressed.Length);

            var byteArrayToSaveDB = new VideoFile() { ByteFile = gifFileByteArrayCompressed };

            await _context.VideoFiles.AddAsync(byteArrayToSaveDB);
            await _context.SaveChangesAsync();

            return View(nameof(VideoToGif));

        }

        [HttpPost]
        public async Task<IActionResult> VideoToVideo(IFormFile file)
        {

            Console.WriteLine("Arquivo de vídeo recebido: " + file.Length);

            var videoFileByteArray = await VideoToByteArray.Converter(file);

            var videoFileByteArrayCompressed = await CompressByteFile.Compress(videoFileByteArray);

            Console.WriteLine("Video byte array comprimido: " + videoFileByteArrayCompressed.Length);

            var byteArrayToSaveDB = new VideoFile() { ByteFile = videoFileByteArrayCompressed };

            await _context.VideoFiles.AddAsync(byteArrayToSaveDB);
            await _context.SaveChangesAsync();

            return View(nameof(VideoToVideo));

        }

    }
}
