namespace CardWebApi1
{
    public class Card
    {
        public string Id { get; set; } = string.Empty;
        public int MemId { get; set; } 
        public int Amount { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
    }
}
