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
using TheBindery.Domain.Agreggates.News;
using TheBindery.Domain.Exceptions;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Services;

namespace TheBindery.Application.RestApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly ITheBinderyContentFactory _theBinderyContentFactory;
        private readonly IMapper _mapper;

        public NewsController(INewsService newsService, ITheBinderyContentFactory theBinderyContentFactory, IMapper mapper)
        {
            _newsService = newsService;
            _theBinderyContentFactory = theBinderyContentFactory;
            _mapper = mapper;
        }


        [HttpPost("")]
        public async Task<IActionResult> Add(NewsRequestResourceModel newsRequestResourceModel)
        {
            try
            {
                var newsId = await _newsService.Add(newsRequestResourceModel.Title,
                                                    newsRequestResourceModel.ContentParagraph,
                                                    newsRequestResourceModel.NewsDate,
                                                    newsRequestResourceModel.Section,
                                                    newsRequestResourceModel.Author);



                return StatusCode((int)HttpStatusCode.Created, new { Message = "News was created successfully.", NewsId = newsId });
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }


        [HttpGet("")]
        public IActionResult GetAllNews()
        {
            try
            {
                var news = ConvertNews(_newsService.GetAll());

                return StatusCode((int)HttpStatusCode.OK, news);
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }


        public ICollection<NewsResponseResourceModel> ConvertNews(IEnumerable<News> news)
        {
            ICollection<NewsResponseResourceModel> newsList = new Collection<NewsResponseResourceModel>();

            foreach (var noticia in news)
            {
                NewsResponseResourceModel newsToAdd = new NewsResponseResourceModel()
                {
                    Id = noticia.Id,
                    Title = noticia.Title,
                    ContentParagraph = noticia.ContentParagraph,
                    Section = noticia.Section,
                    NewsDate = noticia.NewsDate,
                    Author = noticia.Author
                };

                newsList.Add(newsToAdd);
            }

            return newsList;
        }
    }
}
