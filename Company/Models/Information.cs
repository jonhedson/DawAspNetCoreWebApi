using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Information
    {
        public int InformationId { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public DateTime Established { get; set; }
        public decimal Revenue { get; set; }
    }
}
