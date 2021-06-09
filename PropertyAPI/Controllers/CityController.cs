using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyAPI.Data;
using PropertyAPI.Data.Interfaces;
using PropertyAPI.Data.Repo;
using PropertyAPI.DTO;
using PropertyAPI.Models;
//using PropertyAPI.Models;

namespace PropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/city
        [HttpGet("Cities")]
        public async Task<IActionResult> GetCities()
        {
            // TODO: Your code here            
            var cities = await _unitOfWork.CityRepository.GetCitiesAsync();

            var citiesDto = cities.Select(c => new CityDto()
            {
                Id = c.Id,
                Name = c.Name
            });
            return Ok(citiesDto);
        }

        //GET api/city/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var city = await _unitOfWork.CityRepository.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        //POST api/city/add/someName --- POST using JSON
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
                LastUpdatedOn = DateTime.UtcNow,
                LastUpdatedBy = 1
            };

            _unitOfWork.CityRepository.AddCity(city);
            await _unitOfWork.SaveAsync();

            return Ok(city);
        }

        //POST api/city/add?name=someName --- POST using string (Query string)
        //[HttpPost("add/{cityname}")]
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            _unitOfWork.CityRepository.AddCity(city);
            await _unitOfWork.SaveAsync();

            return Ok(city);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityUpdateDto)
        {

            if (id != cityUpdateDto.Id)
            {
                return BadRequest("Update Not allowed");
            }
            var cityToUpdate = await _unitOfWork.CityRepository.GetCity(id);
            //var g = GetCity(id);

            if (cityToUpdate == null)
            {
                return BadRequest("Update Not Allowed");
            }
            cityToUpdate.Name = cityUpdateDto.Name;

            await _unitOfWork.SaveAsync();
            return StatusCode(200);
        }

        //DELETE api/city/
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _unitOfWork.CityRepository.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
            _unitOfWork.CityRepository.DeleteCity(id);
            await _unitOfWork.SaveAsync();
            return Ok(id);
        }
    }
}