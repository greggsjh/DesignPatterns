using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPatterns.CoreObjects.ProxyPattern;
using DesignPatterns.CoreObjects.WebServices;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.WebServices
{
    [ApiController]
    [Route("api/[controller]")]
    public class GumballMachineController : ControllerBase
    {
        private static List<GumballMachine> _machines;
        private readonly static object _sync = new object();
        public GumballMachineController(List<GumballMachine> machines)
        {
            lock (_sync)
            {
                if (_machines == null)
                {
                    _machines = machines;
                }
            }
        }

        [HttpGet("{location}", Name = "GetGumballMachine")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<GumballMachineDto> GetGumballMachine(string location)
        {
            var gm = _machines.Where(m => m.Location.ToLower() == location.ToLower()).FirstOrDefault();
            if (gm == null)
            {
                return NotFound();
            }
            var gumballMachineDto = new GumballMachineDto
            {
                Location = gm.Location,
                Inventory = gm.Count,
                CurrentState = new CurrentStateDto { Name = gm.CurrentState.GetType().Name }
            };

            return gumballMachineDto;
        }

        [HttpPost(Name = "CreateGumballMachine")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult CreateGumballMachine([FromBody] CreateGumballMachineDto gumballMachine)
        {
            if (_machines.Any(m => m.Location.ToLower() == gumballMachine.Location.ToLower()))
            {
                return Conflict();
            }

            var gm = new GumballMachine(gumballMachine.Inventory, gumballMachine.Location);
            _machines.Add(gm);
            var gumballMachineDto = new GumballMachineDto
            {
                Location = gm.Location,
                Inventory = gm.Count,
                CurrentState = new CurrentStateDto { Name = gm.CurrentState.GetType().Name }
            };
            return CreatedAtRoute("GetGumballMachine", new { location = gumballMachine.Location }, gumballMachineDto);
        }

        [HttpOptions]
        public IActionResult GetActions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, HEAD, POST");
            return Ok();
        }
    }
}