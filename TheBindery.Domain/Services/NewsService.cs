using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates.News;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Repositories;

namespace TheBindery.Domain.Services
{
    public class NewsService : INewsService
    {

        private readonly ITheBinderyContentRepository _theBinderyContentRepository;
        private readonly ITheBinderyContentFactory _theBinderyContentFactory;

        public NewsService(ITheBinderyContentRepository theBinderyContentRepository, ITheBinderyContentFactory theBinderyContentFactory)
        {
            _theBinderyContentRepository = theBinderyContentRepository;
            _theBinderyContentFactory = theBinderyContentFactory;
        }

        public async Task<int> Add(string title, string contentParagraph, DateTime? newsDate, string section, string author,int position)
        {
            var news = _theBinderyContentFactory.CreateNews(title, contentParagraph, newsDate, section, author,position);

            var newsToReplaceInPosition = _theBinderyContentRepository.GetNewsByPosition(position);

            if(newsToReplaceInPosition != null)
            {
                newsToReplaceInPosition.Position = 0;
                _theBinderyContentRepository.Update(newsToReplaceInPosition);
            }

            _theBinderyContentRepository.Add(news);


            await _theBinderyContentRepository.Context.CommitAsync();

            return news.Id;
        }

        public IEnumerable<News> GetAll()
        {
            return _theBinderyContentRepository.GetNews();
        }

        public async Task<News> GetById(int id)
        {
            return _theBinderyContentRepository.GetNewsById(id);
        }


        public async Task Update(int id, string title, string contentParagraph, DateTime? newsDate, string section, string author,int position)
        {
            var news = _theBinderyContentRepository.GetNewsById(id);

            var newsToReplaceInPosition = _theBinderyContentRepository.GetNewsByPosition(position);

            if (newsToReplaceInPosition != null)
            {
                newsToReplaceInPosition.Position = 0;
                _theBinderyContentRepository.Update(newsToReplaceInPosition);

            }

            news.Title = title;
            news.ContentParagraph = contentParagraph;
            news.NewsDate = newsDate;
            news.Section = section;
            news.Author = author;
            news.Position = position;


             _theBinderyContentRepository.Update(news);

          await _theBinderyContentRepository.Context.CommitAsync();
        }
    }
}
