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

    }
}