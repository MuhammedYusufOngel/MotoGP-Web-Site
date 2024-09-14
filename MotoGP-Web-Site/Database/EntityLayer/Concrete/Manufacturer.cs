using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class Manufacturer
	{
		[Key]
		public int ManuId { get; set; }
		public string ManuName { get; set; }
    }
}
