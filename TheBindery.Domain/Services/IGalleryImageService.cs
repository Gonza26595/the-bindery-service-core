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
                       string author,
                       int position);

        IEnumerable<GalleryImage> GetAll();

        Task<GalleryImage> GetById(int id);

        Task Update(int id,
                string title,
                string contentParagraph,
                string author,
                int position);
    }
}
