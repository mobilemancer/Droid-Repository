using System.Collections.Generic;

namespace DroidRepository
{
    public class Droid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductSeries { get; set; }
        public List<string> Armaments { get; set; }

    }
}
