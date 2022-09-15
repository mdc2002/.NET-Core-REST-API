using Commander.Models;
using System.Collections.Generic;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        // all an interface is, is just a list of the methods/signatures that you'll provide to the consumer of this interface
        // we're building a REST APi that will perform the typical create/read/update/delete operations
        // and our repository should kind of matter those operations
        // we will start with the Reading operation (giving a list of all our command resources or objects)
        // to do that i need to define an IEnumerable as the return type (and it's going to be of type Command)
        IEnumerable<Command> GetAppCommands();
        // we dont implement anything in the interface, we are just defining the operations or the methods that are available via this interface
        // next step is to return a single command back to the user based on an ID that they are going to provide 
        // return type is command
        Command GetCommandById(int id);



    }
}

