using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZooAPI.Dtos
{
    // Gesamt is used for enumeration. necessary for GetAlleZoosUndCo query
    public class Gesamt
    {
        public long ZooId { get; set; }
        public string ZooOrt { get; set; }
        public string ZooName { get; set; }
        public string MitarbeiterNachname { get; set; }
        public string TierName { get; set; }
        public string Tierart { get; set; }
        public string Gehegeart { get; set; }
        // public long NahrungId { get; set; }
        // public string NahrungName { get; set; }
        // public long MitarbeiterId { get; set; }
        // public long TierId { get; set; }
        // public long GehegeId { get; set; }
        // public long GastId { get; set; }
        // public string GastName { get; set; }
    }
}
