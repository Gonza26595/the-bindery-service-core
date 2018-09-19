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
using TheBindery.Domain.Agreggates;
using TheBindery.Domain.Agreggates.Event;
using TheBindery.Domain.Exceptions;
using TheBindery.Domain.Factories;
using TheBindery.Domain.Services;

namespace TheBindery.Application.RestApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EventsController: ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ITheBinderyContentFactory _theBinderyContentFactory;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, ITheBinderyContentFactory theBinderyContentFactory, IMapper mapper)
        {
            _eventService = eventService;
            _theBinderyContentFactory = theBinderyContentFactory;
            _mapper = mapper;
        }


        [HttpPost("")]
        public async Task<IActionResult> Add(EventRequestResourceModel eventRequestResourceModel)
        {
            try
            {
                var eventId = await _eventService.Add(eventRequestResourceModel.Title,
                                                                    eventRequestResourceModel.ContentParagraph);



                return StatusCode((int)HttpStatusCode.Created, new { Message = "Event was created successfully.", EventId = eventId });
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }

        [HttpGet("")]
        public IActionResult GetAllEvents()
        {
            try
            {
                var events = ConvertEvents(_eventService.GetAll());

                return StatusCode((int)HttpStatusCode.OK, events);
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }


        public ICollection<EventResponseResourceModel> ConvertEvents(IEnumerable<Event> events)
        {
            ICollection<EventResponseResourceModel> eventsList = new Collection<EventResponseResourceModel>();

            foreach (var evento in events)
            {
                EventResponseResourceModel eventToAdd = new EventResponseResourceModel()
                {
                    Id = evento.Id,
                    Title = evento.Title,
                    ContentParagraph = evento.ContentParagraph
                };

                eventsList.Add(eventToAdd);
            }

            return eventsList;
        }


        [HttpGet("{eventId}")]
        public async Task<IActionResult> GetById(int eventId)
        {
            try
            {

                var eventAsigned = await _eventService.GetById(eventId);

                var eventResponseResourceModel = _mapper.Map<Event, EventResponseResourceModel>(eventAsigned);

                return StatusCode((int)HttpStatusCode.OK, eventResponseResourceModel);

            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }



        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateEvent(int eventId,
                                                         EventRequestResourceModel eventRequestResouceModel)
        {
            try
            {
                await _eventService.Update(eventId,
                                           eventRequestResouceModel.Title,
                                           eventRequestResouceModel.ContentParagraph);



                return StatusCode((int)HttpStatusCode.OK, new { Message = "Event was updated successfully." });
            }
            catch (EntityException e)
            {
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, new { e.Message, e.Code, Field = e.Field.ToLower() });
            }
        }
    }
}
