using System.ComponentModel.DataAnnotations.Schema;

namespace f1api.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int DebutYear { get; set; }
        public string CurrentTeam { get; set; }
        public string CarNumber { get; set; }
        public string DebutTeam { get; set; }
        public int? IdDriverStats { get; set; }
        [ForeignKey("IdDriverStats")]
        public DriverStats? DriverStats { get; set; }


    }
}
