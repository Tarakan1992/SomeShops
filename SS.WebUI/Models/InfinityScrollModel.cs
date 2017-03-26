using System.Collections.Generic;

namespace SS.WebUI.Models
{
    public class InfinityScrollModel
    {
        public string Url { get; set; }
        public IEnumerable<string> Params { get; set; }
    }
}
