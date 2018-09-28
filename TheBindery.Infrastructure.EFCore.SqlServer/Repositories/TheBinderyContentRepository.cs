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
using TheBindery.Domain.Repositories;

namespace TheBindery.Infrastructure.EFCore.SqlServer.Repositories
{
    public class TheBinderyContentRepository : Repository<TheBinderyContent>, ITheBinderyContentRepository
    {
        public TheBinderyContentRepository(IRepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Event GetEventById(int id)
        {
            return base.GetAll().OfType<Event>().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Event> GetEvents()
        {
            var list = base.GetAll().OfType<Event>();

            return list;
        }

        public GalleryImage GetGalleryImageById(int id)
        {
            return base.GetAll().OfType<GalleryImage>().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<GalleryImage> GetGalleryImages()
        {
            return base.GetAll().OfType<GalleryImage>();
        }

        public IEnumerable<News> GetNews()
        {
            return base.GetAll().OfType<News>();
        }

        public News GetNewsById(int id)
        {
            return base.GetAll().OfType<News>().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public News GetNewsByPosition(int position)
        {
            return base.GetAll().OfType<News>().Where(x => x.Position.Equals(position)).FirstOrDefault();
        }

        public Event GetEventByPosition(int position)
        {
            return base.GetAll().OfType<Event>().Where(x => x.Position.Equals(position)).FirstOrDefault();
        }

        public GalleryImage GetGalleryImageByPosition(int position)
        {
            return base.GetAll().OfType<GalleryImage>().Where(x => x.Position.Equals(position)).FirstOrDefault();
        }
    }
}
