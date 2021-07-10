using System;

namespace Fields.Configurations.Entities
{
    public class Products
    {
        public string FieldName { get; set; }
        public bool IsRequired { get; set; }
        public int MaxLength { get; set; }
        public string Source { get; set; }
    }
}
