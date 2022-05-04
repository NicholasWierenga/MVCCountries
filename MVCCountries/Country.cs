using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCountries
{
    public class Country
    {
        public enum Region
        {
            North_America,
            South_America,
            Asia,
            Europe,
            Ocenia,
            Africa,
            Antarctica,
        }
        public string Name { get; set; } 
        public Region Continent { get; set; }
        public List<string> Colors { get; set; }
    }
}
