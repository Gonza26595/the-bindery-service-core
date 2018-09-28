using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Application.RestApi.ResourceModels.ResponseResourceModels
{
    public class GalleryImageResponseResourceModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentParagraph { get; set; }
        public string Author { get; set; }
        public int Position { get; set; }
    }
}
