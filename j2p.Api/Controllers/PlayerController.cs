using AutoMapper;
using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels.AddViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
                var response = _playerAppService.Add(playerDomain);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("api/v1/player/delete")]
        public IActionResult Delete([FromBody] PlayerViewModel player)
        {
            try
            {
                var playerDomain = _mapper.Map<PlayerViewModel, Player>(player);
                _playerAppService.Delete(playerDomain);
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
                var response = _playerAppService.Update(playerDomain);
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
                var response = _playerAppService.GetAll();
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
                var response = _playerAppService.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}