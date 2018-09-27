using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates.Event;
using TheBindery.Domain.Agreggates.GalleryImage;
using TheBindery.Domain.Agreggates.News;

namespace TheBindery.Domain.Factories
{
    public class TheBinderyContentFactory : ITheBinderyContentFactory
    {
        public Event CreateEvent(string title, string contentParagraph)
        {
            return new Event(title, contentParagraph);
        }

        public GalleryImage CreateGalleryImage(string title, string contentParagraph, string author)
        {
            return new GalleryImage(title, contentParagraph)
            {
                Author = author
            };
        }

        public News CreateNews(string title, string contentParagraph, DateTime? newsDate, string section, string author,int position)
        {
            return new News(title, contentParagraph)
            {
                NewsDate = newsDate,
                Section = section,
                Author = author,
                Position = position
            };
        }
    }
}
