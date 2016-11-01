namespace SerilogPoc.Models
{
    public class Player
    {
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Alias;
        }
    }
}