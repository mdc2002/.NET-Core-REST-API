using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //this class is going to inherity from a base class called Controller
    //also we want to decorate our class theme with an API controller attribute (gives us some out of the box behaviours that our controller will perform)
    [ApiController]
    [Route("api/commands")] //how do you get to the resources and the API endpoints within my controller
    public class CommandsController : ControllerBase
    // ControllerBase --> A base class for an MVC controller without view support
    {
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //we are now going to create our first action-result endpoint which will realte to getting all of our resources
        //to see these action results respond to HTTP GET request, we will decorate them with HTTP GET
        // The following will respond to: GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands() //returns an IEnumerable of our commands
        {
            // we need to maek use of our repo to pull back data and present that back to the user
            var commandItems = _repository.GetAppCommands();
            return Ok(commandItems);
        }

        // The following will respond to: GET api/commands/{id}
        //now returning back a single resource (in this case it is a command)
        [HttpGet("{id}")] //this gives us a route 
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
        // so we have made two different endpoints that respond to different URIs 

    }
}