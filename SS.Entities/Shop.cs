using System.Collections.Generic;

namespace SS.Entities
{
    public class Shop : EntityBase<int>
    {
        public string Name { get; set; }

        List<Product> Products { get; set; }
    }
}
