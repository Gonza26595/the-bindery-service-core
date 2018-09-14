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


        public IEnumerable<Event> GetEvents()
        {
            var list = base.GetAll().OfType<Event>();

            return list;
        }

        public IEnumerable<GalleryImage> GetGalleryImages()
        {
            return base.GetAll().OfType<GalleryImage>();
        }

        public IEnumerable<News> GetNews()
        {
            return base.GetAll().OfType<News>();
        }
    }
}
