using Commander.Models;

namespace Commander.Data
{
    // now we will create a class that implements the interface
    // not inheritance but implementation
    public class MockCommanderRepo : ICommanderRepo //by putting the : I specify that I want to implement that particular interface
    {
        public IEnumerable<Command> GetAppCommands()
        {
            // now we are going to return a list of mock command objects 
            //new list of command object --> new List<Command>
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an Egg", Line="Boil Water", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut Bread", Line="Get Knife", Platform="Bread Factory"},
                new Command{Id=2, HowTo="code like a brogrammer", Line="DevElOper", Platform="Tech"}
            };
            
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an Egg", Line="Boil Water", Platform="Kettle & Pan"};
        }

        // so what we need to do know is to implement these methods 
        // since it is a mock repo we wont connect to a database, instead we'll throw some hard coded data 
        // so you need to understand the difference between interface and implementation 
    }

}