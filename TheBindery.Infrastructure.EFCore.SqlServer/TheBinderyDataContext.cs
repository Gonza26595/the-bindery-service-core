using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates;
using TheBindery.Domain.Agreggates.Event;
using TheBindery.Domain.Agreggates.GalleryImage;
using TheBindery.Domain.Agreggates.News;

namespace TheBindery.Infrastructure.EFCore.SqlServer
{
    public class TheBinderyDataContext : DbContext
    {
        public TheBinderyDataContext(DbContextOptions options) : base(options) { }


        public DbSet<GalleryImage> GalleryImages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
    }
