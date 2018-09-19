using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates.News;

namespace TheBindery.Domain.Services
{
    public interface INewsService
    {
        Task<int> Add(string title,
                      string contentParagraph,
                      DateTime? newsDate,
                      string section,
                      string author);

        IEnumerable<News> GetAll();

        Task<News> GetById(int id);

        Task Update(int id,
                string title,
                string contentParagraph,
                DateTime? newsDate,
                string section,
                string author);

    }


}
