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
    public class GastController : ControllerBase
    {
        // GET /gast
        [HttpGet("getAll")]
        public IEnumerable<Gast> GetAllGast()
        {
            SQLConnectionGast t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetGast();
        }

        // POST /gast
        [HttpPost("create")]
        public ActionResult<GastInput> CreateGast(GastInput gast)
        {
            SQLConnectionGast t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.CreateGast(gast) >= 1) return gast;
            else throw new Exception("didn't work");
        }

        // PUT /gast
        [HttpPut("update")]
        public ActionResult<int> UpdateGast(long id, GastInput gast)
        {
            SQLConnectionGast t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.UpdateGast(id, gast) == 1) return 1;
            else return NotFound();
        }

        // DELETE /gast
        [HttpDelete("delete")]
        public int DeleteGast(long id)
        {
            SQLConnectionGast t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.DeleteGast(id);
        }
    }
}
