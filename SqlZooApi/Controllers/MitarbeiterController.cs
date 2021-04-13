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
    public class MitarbeiterController : ControllerBase
    {
        // GET /mitarbeiter
        [HttpGet("getAll")]
        public IEnumerable<Mitarbeiter> GetAllMitarbeiter()
        {
            SQLConnectionMitarbeiter t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetMitarbeiter();
        }

        // POST /mitarbeiter
        [HttpPost("create")]
        public ActionResult<MitarbeiterInput> CreateMitarbeiter(MitarbeiterInput mitarbeiter)
        {
            SQLConnectionMitarbeiter t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.CreateMitarbeiter(mitarbeiter) >= 1) return mitarbeiter;
            else throw new Exception("didn't work");
        }

        // PUT /mitarbeiter
        [HttpPut("update")]
        public ActionResult<int> UpdateMitarbeiter(long id, MitarbeiterInput mitarbeiter)
        {
            SQLConnectionMitarbeiter t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.UpdateMitarbeiter(id, mitarbeiter) == 1) return 1;
            else return NotFound();
        }

        // DELETE /mitarbeiter
        [HttpDelete("delete")]
        public int DeleteMitarbeiter(long id)
        {
            SQLConnectionMitarbeiter t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.DeleteMitarbeiter(id);
        }
    }
}
