using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    public class Gehege
    {
        public long Id { get; set; }
        public string Gehegeart { get; set; }
        public long TierID { get; set; }
        public long ZooID { get; set; }
    }
}
