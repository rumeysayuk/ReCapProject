using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _ımageService;
        public CarImagesController(ICarImageService ımageService)
        {
            _ımageService = ımageService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile formFile,[FromForm] CarImage carImage)
        {
            var result = _ımageService.Add(formFile,carImage);
            if (result.Success)
            {
                return Ok(result) ;
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _ımageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile formFile,CarImage carImage)
        {
            var result = _ımageService.Update(formFile, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult Get(int id)
        {
            var result = _ımageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _ımageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getImagesById")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _ımageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
