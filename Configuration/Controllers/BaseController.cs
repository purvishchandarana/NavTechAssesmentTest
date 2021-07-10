using Fields.Configurations.Entities;
using Fields.Configurations.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Configuration.Controllers
{

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        public BaseController()
        {

        }
        
    }
}
