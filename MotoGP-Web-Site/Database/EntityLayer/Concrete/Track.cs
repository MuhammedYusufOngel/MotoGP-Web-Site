using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class Track
	{
		[Key]
		public int TrackId { get; set; }
		public string TrackName { get; set; }
		public string TrackImage { get; set; }
		public string TrackInfo { get; set; }
		public int NationalId { get; set; }
		public National National { get; set; }
	}
}
