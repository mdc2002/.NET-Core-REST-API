namespace Commander.Models
{
    public class Command
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; } //the command line such that we will store in our db
        public string Platform { get; set; }
    }
}