namespace TaskManager_Common
{
    public class Accounts
    {
        public string username { get; set; }
        public string password { get; set; }

        public List<String> Tasks { get; set; }

        public Accounts()
        {
            Tasks = new List<String>();

        }
    }
}
