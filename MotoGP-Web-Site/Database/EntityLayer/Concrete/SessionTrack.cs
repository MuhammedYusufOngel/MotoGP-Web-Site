using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
    public class SessionTrack
    {
        [Key]
        public int Id { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public DateTime Date { get; set; }
        public int Year { get; set; }
    }
}
