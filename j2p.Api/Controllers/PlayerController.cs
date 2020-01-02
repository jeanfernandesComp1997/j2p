using AutoMapper;
using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Presentation.Api.Security;
using j2p.Presentation.Api.ViewModels;
using j2p.Presentation.Api.ViewModels.AddViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

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
        [HttpPost]
        [Route("api/v1/player/autentication")]
        public object Autentication(
            [FromBody]AutenticationViewModel request,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfiguration tokenConfigurations)
        {
            bool validCredentials = false;

            var response = _mapper.Map<Player, PlayerViewModel>(_playerAppService.Authentication(request.Email, request.Password));

            validCredentials = response != null;


            if (validCredentials)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(response.Id.ToString(), "Id"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("User", JsonConvert.SerializeObject(response))
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK",
                    FirstName = response.FirstName,
                    Id = response.Id
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                };
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