using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    // MitarbeiterInput is missing ID, used for user input. ID is generated automatically
    public class MitarbeiterInput
    {
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public int Geburtsjahr { get; set; }
        public long TierID { get; set; }
        public long ZooID { get; set; }
    }
}
