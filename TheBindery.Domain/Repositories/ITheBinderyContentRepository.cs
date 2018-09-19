using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates;
using TheBindery.Domain.Agreggates.Event;
using TheBindery.Domain.Agreggates.GalleryImage;
using TheBindery.Domain.Agreggates.News;

namespace TheBindery.Domain.Repositories
{
    public interface ITheBinderyContentRepository : IRepository<TheBinderyContent> {


        IEnumerable<Event> GetEvents();
        IEnumerable<GalleryImage> GetGalleryImages();

        IEnumerable<News> GetNews();

        Event GetEventById(int id);
        GalleryImage GetGalleryImageById(int id);
        News GetNewsById(int id);

    }

}
