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
    public class NahrungController : ControllerBase
    {
        // GET /nahrung
        [HttpGet("getAll")]
        public IEnumerable<Nahrung> GetAllNahrung()
        {
            SQLConnectionNahrung t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetNahrung();
        }

        // POST /nahrung
        [HttpPost("create")]
        public ActionResult<NahrungInput> CreateNahrung(NahrungInput nahrung)
        {
            SQLConnectionNahrung t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.CreateNahrung(nahrung) >= 1) return nahrung;
            else throw new Exception("didn't work");
        }

        // PUT /nahrung
        [HttpPut("update")]
        public ActionResult<int> UpdateNahrung(long id, NahrungInput nahrung)
        {
            SQLConnectionNahrung t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.UpdateNahrung(id, nahrung) == 1) return 1;
            else return NotFound();
        }

        // DELETE /nahrung
        [HttpDelete("delete")]
        public int DeleteNahrung(long id)
        {
            SQLConnectionNahrung t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.DeleteNahrung(id);
        }
    }
}
