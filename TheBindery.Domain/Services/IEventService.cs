using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates;
using TheBindery.Domain.Agreggates.Event;

namespace TheBindery.Domain.Services
{
    public interface IEventService
    {
        Task<int> Add(string title,
                       string contentParagraph);


        IEnumerable<Event> GetAll();

        Task<Event> GetById(int id);

        Task Update(int id,
                string title,
                string contentParagraph);
    }
}
