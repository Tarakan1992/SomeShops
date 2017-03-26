using SS.Entities;
using System.Collections.Generic;

namespace SS.WebUI.Models
{
    public class ListModel
    {
        public string ItemViewName { get; set; }
        public IEnumerable<IEntity> Items { get; set; }
    }
}
