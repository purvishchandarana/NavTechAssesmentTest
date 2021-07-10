using Fields.Configurations.Entities;
using Fields.Configurations.Interface;
using Fields.Configurations.Repository;
using System;
using System.Collections.Generic;

namespace Fields.Configurations.Business
{
    public class FieldsConfigurationsManager : IFieldsConfigurationsManager
    {
        
        public List<Products> GetConfigurations(string type)
        {
            return new ConfigurationRepository().GetConfigurations(type);
        }
        public string AddUpdateConfigurations(Products prodConfig)
        {
            return new ConfigurationRepository().AddUpdateConfigurations(prodConfig);
        }
    }
}
