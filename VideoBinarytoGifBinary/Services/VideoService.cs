using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public VideoService(Context context, ConverterToDBFormat converterToDBFormat)
        {
            _context = context;
            _converterToDBFormat = converterToDBFormat;
        }

        public async Task<IEnumerable<Video>> ListAsync()
        {
            return  await _context.Videos.ToListAsync();
        }

        public async Task SaveAsync(IFormFile file)
        {
            var videoBase64 = await _converterToDBFormat.Converter(file);
            var video = new Video() { VideoBase64 = videoBase64 };
            await _context.AddAsync(video);
            await _context.SaveChangesAsync();
        }

    }
}
