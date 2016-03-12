using System.Collections.Generic;

namespace Model.SimpleModels
{
    public class StashTab
    {
        public int numTabs { get; set; }
        public IEnumerable<StashItem> items { get; set; }
    }
}