using System.Collections.Generic;
using System.Linq;
using DesignPatterns.CoreObjects.Helpers;
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

        [HttpPut("{location}", Name = "UpdateGumballMachine")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateGumballMachine(string location, [FromBody] UpdateGumballMachineDto gumballMachine)
        {
            var gm = _machines.Where(gm => gm.Location == location).FirstOrDefault();
            if (gm == null)
            {
                return NotFound();
            }

            var defaultStates = new string[] { "NoQuarterState", "HasQuarterState", "SoldOutState", "SoldState", "WinnerState" };

            if (!defaultStates.Any(ds => ds.ToLower() == gumballMachine.CurrentState.Name.ToLower()))
            {
                return BadRequest();
            }

            gm.Count = gumballMachine.Inventory;
            gm.CurrentState = Helper.StateFactory(gumballMachine.CurrentState.Name, gm);
            gm.Location = gumballMachine.Location;

            var gumballMachineDto = new GumballMachineDto
            {
                Location = gm.Location,
                Inventory = gm.Count,
                CurrentState = new CurrentStateDto { Name = gm.CurrentState.GetType().Name }
            };

            return CreatedAtRoute("GetGumballMachine", new { location = gm.Location }, gumballMachineDto);
        }

        [HttpOptions]
        public IActionResult GetActions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, HEAD, PUT, POST");
            return Ok();
        }
    }
}