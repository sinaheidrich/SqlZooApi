using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    // ZooInput is missing ID, used for user input. ID is generated automatically
    public class ZooInput
    {
        public string Ort { get; set; }
        public string Name { get; set; }
    }
}
