using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebJoKenApi.Model;
using WebJoKenApi.Repository;


namespace WebJoKenApi.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : Controller
    {

        private readonly IRepository _service ;
        public PlayerController(IRepository playerRepository)
        {
            _service = playerRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
          
            return new JsonResult(_service.GetPlayers());  
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost()]
        [Route("/Create")]
        public IActionResult Create([FromBody] string name)
        {
            var e = new Model.Player() { Name = name, Points = 0 };
            _service.AddPlayer(e);
            return new NoContentResult();
        }

        //[HttpPost("EndRound")]
        //public void EndRound(Player winner )
        //{
        //    _service.EndRound(winner);   
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public Player Put(Guid id,string jogada)
        {
            var winner = _service.Play(id, jogada);
            return winner;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
