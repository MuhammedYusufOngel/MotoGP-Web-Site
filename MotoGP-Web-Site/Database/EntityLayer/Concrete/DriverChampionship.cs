using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class DriverChampionship
	{
		[Key]
		public int DriverChampId { get; set; }
		public Driver? Driver { get; set; }
		public Team? Team { get; set; }
		public int Points { get; set; }
        public string? Year { get; set; }
    }
}
