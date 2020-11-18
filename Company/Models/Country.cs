using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Country
    {
        public int PId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public DateTime AddedOn { get; set; }
        public ICollection<City> City { get; set; }
    }
}
