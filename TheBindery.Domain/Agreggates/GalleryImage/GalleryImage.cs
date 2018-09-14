using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates.GalleryImage
{
    public class GalleryImage : TheBinderyContent
    {
        public GalleryImage(string title, string contentParagraph) : base(title, contentParagraph)
        {
        }


        public string Author { get; set; }

        private GalleryImage() { }
    }
}
