using AutoMapper;
using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace j2p.Presentation.Api.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventAppService _eventAppService;
        private readonly IMapper _mapper;

        public EventController(IEventAppService eventAppService, ILocalAppService localAppService, IMapper mapper)
        {
            _eventAppService = eventAppService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/event/add")]
        public IActionResult Add([FromBody] EventViewModel eventObj, Guid idOwner, Guid idLocal)
        {
            try
            {
                var eventDomain = _mapper.Map<EventViewModel, Event>(eventObj);
                var response = _mapper.Map<Event, EventViewModel>(_eventAppService.Add(eventDomain, idOwner, idLocal)); 

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/event/subscribeevent")]
        public IActionResult SubscribePlayer([FromBody] SubscribeEventViewModel subscribeEventObj)
        {
            try
            {
                _eventAppService.SubscribeEvent(subscribeEventObj.IdEvent, subscribeEventObj.IdPlayer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/event/unsubscribeevent")]
        public IActionResult UnsubscribeEvent([FromBody] SubscribeEventViewModel subscribeEventObj)
        {
            try
            {
                _eventAppService.UnsubscribeEvent(subscribeEventObj.IdEvent, subscribeEventObj.IdPlayer);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("api/v1/event/delete/{id:Guid}")]
        public IActionResult Delete([FromBody] Guid id)
        {
            try
            {
                _eventAppService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/v1/event/update")]
        public IActionResult Update([FromBody] EventViewModel eventObj)
        {
            try
            {
                var eventDomain = _mapper.Map<EventViewModel, Event>(eventObj);
                var response = _mapper.Map<Event, EventViewModel>(_eventAppService.Update(eventDomain));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/event/getall")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _mapper.Map<IList<Event>, IList<EventViewModel>>(_eventAppService.GetAll());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/event/getbyid/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _mapper.Map<Event, EventViewModel>(_eventAppService.GetById(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/event/findby/{id:Guid}")]
        public IActionResult FindBy(Guid id)
        {
            try
            {
                Expression<Func<Event, bool>> filter = x => x.Players.Any(y => y.Id == id);
                var response = _mapper.Map<IList<Event>, IList<EventViewModel>>(_eventAppService.FindBy(filter));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}