using Fields.Configurations.Entities;
using System;
using System.Collections.Generic;

namespace Fields.Configurations.Interface
{
    public interface IFieldsConfigurationsManager
    {
        List<Products> GetConfigurations(string type);
        string AddUpdateConfigurations(Products prodConfig);
    }
}
