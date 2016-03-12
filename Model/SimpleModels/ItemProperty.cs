using System.Collections.Generic;

namespace Model.SimpleModels
{
    public class ItemProperty
    {
        public string name { get; set; }
        public IEnumerable<object> values { get; set; }

        public int displayMode { get; set; }
    }
}