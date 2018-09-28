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
        public Event CreateEvent(string title, string contentParagraph,int position)
        {
            return new Event(title, contentParagraph,position);
        }

        public GalleryImage CreateGalleryImage(string title, string contentParagraph, string author,int position)
        {
            return new GalleryImage(title, contentParagraph,position)
            {
                Author = author
            };
        }

        public News CreateNews(string title, string contentParagraph, DateTime? newsDate, string section, string author,int position)
        {
            return new News(title, contentParagraph,position)
            {
                NewsDate = newsDate,
                Section = section,
                Author = author,
            };
        }
    }
}
