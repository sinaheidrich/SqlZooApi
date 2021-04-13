using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using ZooAPI;
using ZooAPI.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using ZooAPI.Connections;

namespace ZooAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZooController : ControllerBase
    {
        // GET /zoos
        [HttpGet("getAll")]
        public IEnumerable<Zoo> GetAllZoo()
        {
            SQLConnectionZoo t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetZoo();
        }

        // POST /zoos
        [HttpPost("create")]
        public ActionResult<ZooInput> CreateZoo(ZooInput zoo)
        {
            SQLConnectionZoo t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.CreateZoo(zoo) >= 1) return zoo;
            else throw new Exception("didn't work");
        }

        // PUT /zoos
        [HttpPut("update")]
        public ActionResult<int> UpdateZoo(long id, ZooInput zoo)
        {
            SQLConnectionZoo t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.UpdateZoo(id, zoo) == 1) return 1;
            else return NotFound();
        }

        // DELETE /zoos
        [HttpDelete("delete")]
        public int DeleteZoo(long id)
        {
            SQLConnectionZoo t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.DeleteZoo(id);
        }
    }
}