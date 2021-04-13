using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    public class Tier
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tierart { get; set; }
        public long ZooID { get; set; }
        public Boolean Vegetarier { get; set; }
    }
}
