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
    public class TiereController : ControllerBase
    {
        // GET /tiere
        [HttpGet("getAll")]
        public IEnumerable<Tier> GetAllTier()
        {
            SQLConnectionTier t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.GetTier();
        }

        // POST /tiere
        [HttpPost("create")]
        public ActionResult<TierInput> CreateTier(TierInput tier)
        {
            SQLConnectionTier t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.CreateTier(tier) >= 1) return tier;
            else throw new Exception("didn't work");
        }

        // PUT /tiere
        [HttpPut("update")]
        public ActionResult<int> UpdateTier(long id, TierInput tier)
        {
            SQLConnectionTier t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            if (t.UpdateTier(id, tier) == 1) return 1;
            else return NotFound();
        }

        // DELETE /tiere
        [HttpDelete("delete")]
        public int DeleteTier(long id)
        {
            SQLConnectionTier t = new("server=localhost;port=3306;database=ZooDatenbank;user=root;password=root");
            return t.DeleteTier(id);
        }
    }
}


