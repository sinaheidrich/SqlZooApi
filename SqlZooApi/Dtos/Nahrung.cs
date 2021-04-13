using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    public class Nahrung
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Kilokalorien { get; set; }
        public long TierID { get; set; }
        public long ZooID { get; set; }
    }
}
