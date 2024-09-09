using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class National
	{
		[Key]
		public int NationalId { get; set; }
		public string NationalName { get; set; }
		public string NationalImage { get; set; }
	}
}
