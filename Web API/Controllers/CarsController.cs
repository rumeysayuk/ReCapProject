using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Controllers
{
    public class CarsController : ControllerBase
    {
        Route[("Api/[contoller]")]
       [ApiController]      
            public IActionResult Post()
        {
           
        }
    }
}
