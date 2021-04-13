using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    // NahrungInput is missing ID, used for user input. ID is generated automatically
    public class NahrungInput
    {
        public string Name { get; set; }
        public int Kilokalorien { get; set; }
        public long TierID { get; set; }
        public long ZooID { get; set; }
    }
}
