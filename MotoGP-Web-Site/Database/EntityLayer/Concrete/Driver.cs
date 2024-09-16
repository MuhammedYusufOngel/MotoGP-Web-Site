
using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class Driver
	{
		[Key]
		public int DriverId { get; set; }
		public int DriverNumber { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public int NationalId { get; set; }
		public National National { get; set; }
		public string? RiderStory { get; set; }
	}
}
