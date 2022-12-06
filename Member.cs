namespace CardWebApi1
{
    public class Member
    {
        public int MID { get; set; }
        public string Id { get; set; }
        public string fName { get; set; } = string.Empty;
        public string lName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ProfilePath { get; set; } = string.Empty;
    }
}
