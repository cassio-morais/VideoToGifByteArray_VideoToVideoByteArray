using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBinarytoGifBinary.Data.Entity;
using VideoBinarytoGifBinary.Models;
using VideoBinarytoGifBinary.Utils;

namespace VideoBinarytoGifBinary.Services
{
    public class VideoService
    {
        private readonly Context _context;
        private readonly ConverterToDBFormat _converterToDBFormat;
        private readonly ConverterToViewFormat _converterToViewFormat;

        public VideoService(Context context, ConverterToDBFormat converterToDBFormat, ConverterToViewFormat converterToViewFormat)
        {
            _context = context;
            _converterToDBFormat = converterToDBFormat;
            _converterToViewFormat = converterToViewFormat;
        }

        public async Task<IEnumerable<Video>> ListAsync()
        {
            var videosToConverterToBase64 = await _context.Videos.ToListAsync();
            var videosBase64 = new List<Video>();

            foreach (var video in videosToConverterToBase64)
            {
                var vid64 = await _converterToViewFormat.Converter(video);
                videosBase64.Add(vid64);
            };

            return videosBase64;
        }

        public async Task SaveAsync(IFormFile file)
        {
            var videoByteArray = await _converterToDBFormat.Converter(file);
            var video = new VideoByteArray { VideoByte = videoByteArray };
            await _context.AddAsync(video);
            await _context.SaveChangesAsync();
        }

    }
}
