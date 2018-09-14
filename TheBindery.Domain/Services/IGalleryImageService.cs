using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates.GalleryImage;

namespace TheBindery.Domain.Services
{
    public interface IGalleryImageService
    {
        Task<int> Add(string title,
                       string contentParagraph,
                       string author);

        IEnumerable<GalleryImage> GetAll();
    }
}
