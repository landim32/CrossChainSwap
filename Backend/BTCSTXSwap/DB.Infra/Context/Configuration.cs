using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Infra.Context
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
