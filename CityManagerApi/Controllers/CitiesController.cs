using AutoMapper;
using CityManagerApi.Data;
using CityManagerApi.Dtos;
using CityManagerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IAppRepository _appRepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository appRepository, IMapper mapper)
        {
            _appRepository = appRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCities()
        {
            //var cities = _appRepository.GetCities(1)
            //    .Select(c => new CityForListDto()
            //    {
            //         Id = c.Id,
            //         Description = c.Description,
            //         CityImageUrl = c.CityImages.FirstOrDefault(p => p.IsMain).Url,
            //         Name = c.Name
            //});

            var cities = _appRepository.GetCities(1);
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);

            return Ok(citiesToReturn);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(CityAddDto dto)
        {
            var item = _mapper.Map<City>(dto);
            _appRepository.Add(item);
            _appRepository.SaveAll();
            return Ok(item);
        }

        [HttpGet("Detail")]
        public IActionResult GetCityById(int id)
        {
            var city = _appRepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }

        [HttpGet("CityImages/{cityId}")]
        public IActionResult GetCityImagesByCityId(int cityId)
        {
            var CityImages = _appRepository.GetCityImagesByCityId(cityId);
            var CityImagesToReturn = _mapper.Map<CityImageDto>(CityImages);
            return Ok(CityImagesToReturn);
        }
        
    }
}
