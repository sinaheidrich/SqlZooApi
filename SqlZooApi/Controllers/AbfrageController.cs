using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Connections;
using ZooAPI.Dtos;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AbfrageController : ControllerBase
    {
        // GET alle Besucher eines bestimmten Tieres
        [HttpGet("alle Besucher von Tier")]
        public IEnumerable<Gast> GetAlleBesucher(long id)
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetAlleBesucher(id);
        }

        // GET alle Tiere ohne Besucher
        [HttpGet("alle Tiere ohne Besucher")]
        public IEnumerable<Tier> GetAlleTiereOhneGast()
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetAlleTiereOhneGast();
        }

        // GET alle Tiere ohne Pfleger
        [HttpGet("alle Tiere ohne Pfleger")]
        public IEnumerable<Tier> GetAlleTiereOhneMitarbeiter()
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetAlleTiereOhneMitarbeiter();
        }

        // GET Nahrung eines bestimmten Tieres
        [HttpGet("Nahrung von Tier")]
        public IEnumerable<Nahrung> GetNahrungTier(long id)
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetNahrungTier(id);
        }

        // GET vegetarische Tiere
        [HttpGet("alle vegetarischen Tiere")]
        public IEnumerable<Tier> GetVegetarier()
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetVegetarier();
        }

        // GET carnivore Tiere
        [HttpGet("alle carnivoren Tiere")]
        public IEnumerable<Tier> GetCarnivore()
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetCarnivore();
        }

        // GET alle gepflegten Tiere eines Mitarbeiters 
        [HttpGet("alle gepflegten Tiere von Mitarbeiter")]
        public IEnumerable<Tier> GetGepflegteTiereMitarbeiter(string nachname)
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetGepflegteTiereMitarbeiter(nachname);
        }

        // GET alle Zoos inklusive Tiere, Mitarbeiter, ...
        [HttpGet("alle Zoos und Co.")]
        public IEnumerable<Gesamt> GetAlleZoosUndCo()
        {
            SQLConnectionAbfragen t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetAlleZoosUndCo();
        }
    }
}