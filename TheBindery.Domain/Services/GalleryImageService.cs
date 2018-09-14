using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates.GalleryImage;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Repositories;

namespace TheBindery.Domain.Services
{
    public class GalleryImageService : IGalleryImageService
    {

        private readonly ITheBinderyContentRepository _theBinderyContentRepository;
        private readonly ITheBinderyContentFactory _theBinderyContentFactory;

        public GalleryImageService(ITheBinderyContentRepository theBinderyContentRepository, ITheBinderyContentFactory theBinderyContentFactory)
        {
            _theBinderyContentRepository = theBinderyContentRepository;
            _theBinderyContentFactory = theBinderyContentFactory;
        }

        public async Task<int> Add(string title, string contentParagraph, string author)
        {
            var galleryImage = _theBinderyContentFactory.CreateGalleryImage(title, contentParagraph, author);

            _theBinderyContentRepository.Add(galleryImage);

            await _theBinderyContentRepository.Context.CommitAsync();

            return galleryImage.Id;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
           return  _theBinderyContentRepository.GetGalleryImages();
        }
    }
}
