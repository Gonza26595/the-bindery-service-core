using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Application.RestApi.ResourceModels.RequestResourceModels;
using TheBindery.Application.RestApi.ResourceModels.ResponseResourceModels;
using TheBindery.Domain.Agreggates.GalleryImage;
using TheBindery.Domain.Exceptions;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Services;

namespace TheBindery.Application.RestApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class GalleryImagesController : ControllerBase
    {
        private readonly IGalleryImageService _galleryImageService;
        private readonly ITheBinderyContentFactory _theBinderyContentFactory;
        private readonly IMapper _mapper;

        public GalleryImagesController(IGalleryImageService galleryImageService, ITheBinderyContentFactory theBinderyContentFactory, IMapper mapper)
        {
            _galleryImageService = galleryImageService;
            _theBinderyContentFactory = theBinderyContentFactory;
            _mapper = mapper;
        }


        [HttpPost("")]
        public async Task<IActionResult> Add(GalleryImageRequestResourceModel galleryImageRequestResourceModel)
        {
            try
            {
                var galleryImageId = await _galleryImageService.Add(galleryImageRequestResourceModel.Title,
                                                                    galleryImageRequestResourceModel.ContentParagraph,
                                                                    galleryImageRequestResourceModel.Author,
                                                                    galleryImageRequestResourceModel.Position);


                return StatusCode((int)HttpStatusCode.Created, new { Message = "Image was created successfully.", GalleryImageId = galleryImageId });
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }

        [HttpGet("")]
        public IActionResult GetAllImages()
        {
            try
            {
                var images = ConvertImages(_galleryImageService.GetAll());

                return StatusCode((int)HttpStatusCode.OK, images);
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }


        public ICollection<GalleryImageResponseResourceModel> ConvertImages(IEnumerable<GalleryImage> images)
        {
            ICollection<GalleryImageResponseResourceModel> imagesList = new Collection<GalleryImageResponseResourceModel>();

            foreach (var image in images)
            {
                GalleryImageResponseResourceModel imageToAdd = new GalleryImageResponseResourceModel()
                {
                    Id = image.Id,
                    Title = image.Title,
                    ContentParagraph = image.ContentParagraph,
                    Author = image.Author,
                    Position = image.Position
                };

                imagesList.Add(imageToAdd);
            }

            return imagesList;
        }


        [HttpGet("{galleryImageId}")]
        public async Task<IActionResult> GetById(int galleryImageId)
        {
            try
            {

                var galleryImage = await _galleryImageService.GetById(galleryImageId);

                var galleryImageResponseResourceModel = _mapper.Map<GalleryImage,GalleryImageResponseResourceModel>(galleryImage);

                return StatusCode((int)HttpStatusCode.OK, galleryImageResponseResourceModel);

            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }


        [HttpPut("{galleryImageId}")]
        public async Task<IActionResult> UpdateGalleryImage(int galleryImageId,
                                                         GalleryImageRequestResourceModel galleryImageRequestResouceModel)
        {
            try
            {
                await _galleryImageService.Update(galleryImageId,
                                           galleryImageRequestResouceModel.Title,
                                           galleryImageRequestResouceModel.ContentParagraph,
                                           galleryImageRequestResouceModel.Author,
                                           galleryImageRequestResouceModel.Position);



                return StatusCode((int)HttpStatusCode.OK, new { Message = "Image was updated successfully." });
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }


    }
}
