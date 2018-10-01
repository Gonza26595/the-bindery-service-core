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

        public async Task<int> Add(string title, string contentParagraph,int position)
        {
            var theBinderyEvent = _theBinderyContentFactory.CreateEvent(title, contentParagraph,position);

            var eventToReplaceInPosition = _theBinderyContentRepository.GetEventByPosition(position);

            if (eventToReplaceInPosition != null)
            {
                eventToReplaceInPosition.Position = 0;
                _theBinderyContentRepository.Update(eventToReplaceInPosition);
            }

            _theBinderyContentRepository.Add(theBinderyEvent);

            await _theBinderyContentRepository.Context.CommitAsync();

            return theBinderyEvent.Id;
        }

        public IEnumerable<Event> GetAll()
        {
            return _theBinderyContentRepository.GetEvents();
        }

        public async Task<Event> GetById(int id)
        {
            return _theBinderyContentRepository.GetEventById(id);
        }

        public async Task Update(int id, string title, string contentParagraph,int position)
        {
            var eventToUpdate = _theBinderyContentRepository.GetEventById(id);

            var eventToReplaceInPosition = _theBinderyContentRepository.GetEventByPosition(position);

            if (eventToReplaceInPosition != null)
            {
                eventToReplaceInPosition.Position = 0;
                _theBinderyContentRepository.Update(eventToReplaceInPosition);

            }

            eventToUpdate.Title = title;
            eventToUpdate.ContentParagraph = contentParagraph;
            eventToUpdate.Position = position;

             _theBinderyContentRepository.Update(eventToUpdate);

            await _theBinderyContentRepository.Context.CommitAsync();
        }
    }

}
