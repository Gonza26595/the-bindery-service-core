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


        public DbSet<TheBinderyContent> TheBinderyContent { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GalleryImage>().HasBaseType<TheBinderyContent>();

            modelBuilder.Entity<Event>().HasBaseType<TheBinderyContent>();

            modelBuilder.Entity<News>().HasBaseType<TheBinderyContent>();
        }
    }
    }
