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

        public async Task<int> Add(string title, string contentParagraph, string author,int position)
        {
            var galleryImage = _theBinderyContentFactory.CreateGalleryImage(title, contentParagraph, author,position);

            var imageToReplaceInPosition = _theBinderyContentRepository.GetGalleryImageByPosition(position);

            if (imageToReplaceInPosition != null)
            {
                imageToReplaceInPosition.Position = 0;
                _theBinderyContentRepository.Update(imageToReplaceInPosition);
            }

            _theBinderyContentRepository.Add(galleryImage);

            await _theBinderyContentRepository.Context.CommitAsync();

            return galleryImage.Id;
        }

        public IEnumerable<GalleryImage> GetAll()
        {
           return  _theBinderyContentRepository.GetGalleryImages();
        }

        public async Task<GalleryImage> GetById(int id)
        {
            return _theBinderyContentRepository.GetGalleryImageById(id);
        }

        public async Task Update(int id, string title, string contentParagraph, string author,int position)
        {
            var galleryImage = _theBinderyContentRepository.GetGalleryImageById(id);

            var imageToReplaceInPosition = _theBinderyContentRepository.GetGalleryImageByPosition(position);

            if (imageToReplaceInPosition != null)
            {
                imageToReplaceInPosition.Position = 0;
                _theBinderyContentRepository.Update(imageToReplaceInPosition);

            }

            galleryImage.Title = title;
            galleryImage.ContentParagraph = contentParagraph;
            galleryImage.Author = author;
            galleryImage.Position = position;

             _theBinderyContentRepository.Update(galleryImage);

            await _theBinderyContentRepository.Context.CommitAsync();
        }
    }
}
