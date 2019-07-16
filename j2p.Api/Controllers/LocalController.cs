using AutoMapper;
using j2p.Application.Interfaces;
using j2p.Domain.Entities;
using j2p.Presentation.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace j2p.Presentation.Api.Controllers
{
    public class LocalController : Controller
    {
        private readonly ILocalAppService _localAppService;
        private readonly IMapper _mapper;

        public LocalController(ILocalAppService localAppService, IMapper mapper)
        {
            _localAppService = localAppService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/local/add/{idOwner:Guid}")]
        public IActionResult Add([FromBody] LocalViewModel local, Guid idOwner)
        {
            try
            {
                var localDomain = _mapper.Map<LocalViewModel, Local>(local);
                var response = _localAppService.Add(localDomain, idOwner);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("api/v1/local/delete/{id:Guid}")]
        public IActionResult Delete([FromBody] Guid id)
        {
            try
            {
                _localAppService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/v1/local/update")]
        public IActionResult Update([FromBody] LocalViewModel local)
        {
            try
            {
                var localDomain = _mapper.Map<LocalViewModel, Local>(local);
                var response = _localAppService.Update(localDomain);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/local/getall")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _mapper.Map<IList<Local>, IList<LocalViewModel>>(_localAppService.GetAll());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/local/getbyid/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _mapper.Map<Local, LocalViewModel>(_localAppService.GetById(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}