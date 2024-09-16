using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class Team
	{
		[Key]
		public int TeamId { get; set; }
		public string TeamName { get; set; }
		public string TeamImage { get; set; }
		public string TeamColor { get; set; }
		public int ManufacturerManuId { get; set; }
		public Manufacturer Manufacturer { get; set; }
    }
}
