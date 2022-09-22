﻿using ConfigurationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly SampleService _service;

        public SampleController(SampleService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetOptions()
        {
            var options = _service.GetOptions();
            return Ok(options);
        }
    }
}
