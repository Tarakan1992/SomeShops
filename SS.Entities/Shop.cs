using System;
using System.Collections.Generic;

namespace SS.Entities
{
    public class Shop : EntityBase<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        List<Product> Products { get; set; }
    }
}
