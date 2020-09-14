using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VideoBinarytoGifBinary.Services;

namespace VideoBinarytoGifBinary.Controllers
{
    public class VideosController : Controller
    {
        private readonly VideoService _videoService;

        public VideosController(VideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var videos = await _videoService.ListAsync();

            return View(videos);
        }

        [HttpGet]
        public IActionResult UploadVideo()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UploadVideo(IFormFile file)
        {
            if (!file.FileName.EndsWith(".mp4")) // implementar
            {
                return NotFound(); // implementar
            }

            await _videoService.SaveAsync(file);
            return RedirectToAction(nameof(Index));
        }
    }
}
