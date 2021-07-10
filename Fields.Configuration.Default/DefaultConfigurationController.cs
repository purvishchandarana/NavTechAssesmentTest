using Configuration.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Fields.Configuration.Default
{
    [ApiController]
    public class DefaultConfigurationController : BaseController
    {
        [HttpGet]
        [Route("Default/GetDefaultConfigurations")]
        public string[] GetDefaultConfigurations()
        {
            return base.GetConfigurations("Default");
        }
    }
}
