using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //this class is going to inherity from a base class called Controller
    [Route("api/commands")] //how do you get to the resources and the API endpoints within my controller
    //also we want to decorate our class theme with an API controller attribute (gives us some out of the box behaviours that our controller will perform)
    [ApiController]
    public class CommandsController : ControllerBase
    // ControllerBase --> A base class for an MVC controller without view support
    {
        private readonly ICommanderRepo _repository;

        //as said, we need to cretae a constructor in order for the dependency to be injected
        //shortcut -> ctor (to make a constructor)
        //for easiness we will create the ICommanderRepo as repository
        public CommandsController(ICommanderRepo repository)
        {
            //we want whatever is injected via the DIS into the repository parameter, we want to assign it to _repository
            _repository = repository;
        }
        // when we use DI, this pattern shows up very often (the constructor, having some attributes created in the parameters, private readonly fields denoted by underscore, and finally assigning hte dependency injected value to our private field for use with the rest of the class)

        // we comment the following one as we won't use it anymore
        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
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
        // so we have created two different API endpoints that respond to different URIs 

    }
}


// now instead of asking for a concrete implementation of a class we will move to asking for an implementation of our interface
// and in the backend, using dependency injection, we can swap out how we implement that interface and our CommandsController class doesn't care how we've implemented it 