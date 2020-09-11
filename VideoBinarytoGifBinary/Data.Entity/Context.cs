using Microsoft.EntityFrameworkCore;
using VideoBinarytoGifBinary.Models;

namespace VideoBinarytoGifBinary.Data.Entity
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<VideoFile> VideoFiles { get; set; }

    }
}
