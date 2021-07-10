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
    public class DefaultConfigurationController : BaseController
    {
        private static IFieldsConfigurationsManager _fieldsConfigurations;
        public DefaultConfigurationController(IFieldsConfigurationsManager fieldsConfigurations) :base()
        {
            _fieldsConfigurations = fieldsConfigurations;
        }
        /// <summary>
        /// Get Default Configurations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(CommonConstants.GetDefaultConfigurations)]
        public List<Products> GetDefaultConfigurations()
        {
            return _fieldsConfigurations.GetConfigurations("Default");
        }
        /// <summary>
        /// Get Custom Configurations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(CommonConstants.GetCustomConfigurations)]
        public List<Products> GetCustomConfigurations()
        {
            return _fieldsConfigurations.GetConfigurations("Custom");
        }
        /// <summary>
        /// Insert UPDATE Config
        /// </summary>
        /// <param name="prodConfig"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(CommonConstants.InsertConfig)]
        public string AddUpdateConfigurations(Products prodConfig)
        {
            return _fieldsConfigurations.AddUpdateConfigurations(prodConfig);
        }
        
    }
}
