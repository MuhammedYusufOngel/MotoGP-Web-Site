using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class Result
	{
		[Key]
		public int Id { get; set; }
		public DriverChampionship DriverChamp { get; set; }
		public SessionTrack SessionTrack { get; set; }
		public TimeSpan Time { get; set; }
		public int? Points { get; set; }
	}
}
