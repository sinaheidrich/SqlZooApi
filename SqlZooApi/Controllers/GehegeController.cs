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
    public class GehegeController : ControllerBase
    {
        // GET /gehege
        [HttpGet("getAll")]
        public IEnumerable<Gehege> GetAllGehege()
        {
            SQLConnectionGehege t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetGehege();
        }

        // POST /gehege
        [HttpPost("create")]
        public ActionResult<GehegeInput> CreateGehege(GehegeInput gehege)
        {
            SQLConnectionGehege t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.CreateGehege(gehege) >= 1) return gehege;
            else throw new Exception("didn't work");
        }

        // PUT /gehege
        [HttpPut("update")]
        public ActionResult<int> UpdateGehege(long id, GehegeInput gehege)
        {
            SQLConnectionGehege t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.UpdateGehege(id, gehege) == 1) return 1;
            else return NotFound();
        }

        // DELETE /gehege
        [HttpDelete("delete")]
        public int DeleteGehege(long id)
        {
            SQLConnectionGehege t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.DeleteGehege(id);
        }
    }
}

