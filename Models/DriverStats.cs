namespace f1api.Models
{
    public class DriverStats
    {
        public int Id { get; set; }
        public int IdDriver { get; set; }
        public Driver Driver { get; set;} 
        public int Titles { get; set; }
        public int Wins { get; set; }
        public int Podiums { get; set; }
        public int Poles { get; set; }
        public int FastestLaps { get; set; }
        public float Points { get; set; }

    }
}
