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
    public interface ITheBinderyContentFactory
    {
        News CreateNews(string title,
                        string contentParagraph,
                        DateTime? newsDate,
                        string section,
                        string author,
                        int position);

        Event CreateEvent(string title,
                          string contentParagraph,
                          int position);


        GalleryImage CreateGalleryImage(string title,
                                        string contentParagraph,
                                        string author,
                                        int position);



    }
}
