using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : ControllerBase
    {
        IFindeksService _findeksService;
        public FindeksController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int findeksId)
        {
            var result = _findeksService.GetById(findeksId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _findeksService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _findeksService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("update")]
        public IActionResult Update(Findeks findeks)
        {
            var result = _findeksService.Update(findeks);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(Findeks findeks)
        {
            var result = _findeksService.Add(findeks);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
