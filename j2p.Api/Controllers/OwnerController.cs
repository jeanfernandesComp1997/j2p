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
    public class OwnerController : Controller
    {
        private readonly IOwnerAppService _ownerAppService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerAppService ownerAppService, IMapper mapper)
        {
            _ownerAppService = ownerAppService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/v1/owner/add")]
        public IActionResult Add([FromBody] OwnerViewModel owner)
        {
            try
            {
                var ownerDomain = _mapper.Map<OwnerViewModel, Owner>(owner);
                var response = _mapper.Map<Owner, OwnerViewModel>(_ownerAppService.Add(ownerDomain));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("api/v1/owner/delete/{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _ownerAppService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("api/v1/owner/update")]
        public IActionResult Update([FromBody] OwnerViewModel owner)
        {
            try
            {
                var ownerDomain = _mapper.Map<OwnerViewModel, Owner>(owner);
                var response = _mapper.Map<Owner, OwnerViewModel>(_ownerAppService.Update(ownerDomain));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/owner/getall")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _mapper.Map<IList<Owner>, IList<OwnerViewModel>>(_ownerAppService.GetAll());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/v1/owner/getbyid/{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var response = _mapper.Map<Owner, OwnerViewModel>(_ownerAppService.GetById(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}