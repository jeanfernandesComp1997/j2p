using j2p.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace j2p.Presentation.Api.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerAppService _playerAppService;

        public PlayerController(IPlayerAppService playerAppService)
        {
            _playerAppService = playerAppService;
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
    }
}