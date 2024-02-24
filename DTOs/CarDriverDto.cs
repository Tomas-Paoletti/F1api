namespace f1api.DTOs
{
    public class CarDriverDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string National { get; set; }
        public string CurrentTeam { get; set; }
        public string CarNumber { get; set; }
        public string? DebutTeam { get; set; }
    }
}
