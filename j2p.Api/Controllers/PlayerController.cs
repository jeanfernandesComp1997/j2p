using AutoMapper;
using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels.AddViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace j2p.Presentation.Api.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerAppService _playerAppService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerAppService playerAppService, IMapper mapper)
        {
            _playerAppService = playerAppService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/player/add")]
        public IActionResult Add([FromBody] PlayerViewModel player)
        {
            try
            {
                var playerDomain = _mapper.Map<PlayerViewModel, Player>(player);
                var response = _mapper.Map<Player, PlayerViewModel>(_playerAppService.Add(playerDomain));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("api/v1/player/delete/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _playerAppService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/v1/player/update")]
        public IActionResult Update([FromBody] PlayerViewModel player)
        {
            try
            {
                var playerDomain = _mapper.Map<PlayerViewModel, Player>(player);
                var response = _mapper.Map<Player, PlayerViewModel>(_playerAppService.Update(playerDomain));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/player/getall")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _mapper.Map<IList<Player>, IList<PlayerViewModel>>(_playerAppService.GetAll());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/player/getbyid/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _mapper.Map<Player, PlayerViewModel>(_playerAppService.GetById(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}