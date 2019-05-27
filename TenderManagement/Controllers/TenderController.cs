using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TM.Data;
using TM.Data.Repository;

namespace TenderManagement.Controllers
{
    [Route("api/[controller]")]
    public class TenderController : Controller
    {
        private ITenderRepository _repository;

        public TenderController(ITenderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("Tender Id is required");
            }
            try
            {
                return Ok(_repository.Get(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Tender tender)
        {
            if (tender == null)
            {
                return BadRequest("Tender is required");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(500, ModelState);
            }
            try
            {
                return Ok(_repository.Create(tender));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Tender tender, int id)
        {
            if (tender == null)
            {
                return BadRequest("Tender is required");
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(500, ModelState);
            }
            try
            {
                return Ok(_repository.Update(tender));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Tender id is required");
            }

           
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
