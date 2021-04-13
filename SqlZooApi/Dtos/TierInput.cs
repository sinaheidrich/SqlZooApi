using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    // TierInput is missing ID, used for user input. ID is generated automatically
    public class TierInput
    {
        public string Name { get; set; }
        public string Tierart { get; set; }
        public int ZooID { get; set; }
        public Boolean Vegetarier { get; set; }
    }
}
