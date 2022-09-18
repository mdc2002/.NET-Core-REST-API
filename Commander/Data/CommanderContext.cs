using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext //we want our class to inherit from DbContext
    {
        //now we need to define a constructor (shortcut ctor)
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        //the parameters we want to pass are some options (DbContextOptions) of type CommanderContext
        {
            
        }
    }
}