﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VideoBinarytoGifBinary.Utils
{
    public class VideoToByteArray
    {

        public static async Task<byte[]> Converter(IFormFile file)
        {
        
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var fileFormatToBytes = ms.ToArray();

            return fileFormatToBytes;

        }
    }
}