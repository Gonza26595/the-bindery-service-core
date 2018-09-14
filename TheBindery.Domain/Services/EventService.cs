using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates;
using TheBindery.Domain.Agreggates.Event;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Repositories;

namespace TheBindery.Domain.Services
{
    public class EventService : IEventService
    {
        private readonly ITheBinderyContentRepository _theBinderyContentRepository;
        private readonly ITheBinderyContentFactory _theBinderyContentFactory;

        public EventService(ITheBinderyContentRepository theBinderyContentRepository, ITheBinderyContentFactory theBinderyContentFactory)
        {
            _theBinderyContentRepository = theBinderyContentRepository;
            _theBinderyContentFactory = theBinderyContentFactory;
        }

        public async Task<int> Add(string title, string contentParagraph)
        {
            var theBinderyEvent = _theBinderyContentFactory.CreateEvent(title, contentParagraph);

             _theBinderyContentRepository.Add(theBinderyEvent);

            await _theBinderyContentRepository.Context.CommitAsync();

            return theBinderyEvent.Id;
        }

        public IEnumerable<Event> GetAll()
        {
            return _theBinderyContentRepository.GetEvents();
        }
    }

}
