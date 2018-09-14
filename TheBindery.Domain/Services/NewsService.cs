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

        public async Task<int> Add(string title, string contentParagraph, DateTime? newsDate, string section, string author)
        {
            var news = _theBinderyContentFactory.CreateNews(title, contentParagraph, newsDate, section, author);

            _theBinderyContentRepository.Add(news);

            await _theBinderyContentRepository.Context.CommitAsync();

            return news.Id;
        }

        public IEnumerable<News> GetAll()
        {
            return _theBinderyContentRepository.GetNews();
        }
    }
}
