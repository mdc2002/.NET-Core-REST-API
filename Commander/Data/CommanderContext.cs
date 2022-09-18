using Commander.Models;
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

        // next thing to do is to create a representation of our Command model in our database, and the way we do that is with the db set (defined as a property)

        public DbSet<Command> Commands { get; set; }
        // so what we want is to represent our Command object down to our database as a DbSet and it is going to be called Commands
        // we have our DbContext, and our database (SQLServer), and we need to connect these two
        // we'll do this with a connection string
    }
}