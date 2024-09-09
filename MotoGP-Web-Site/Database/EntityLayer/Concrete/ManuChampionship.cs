using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class ManuChampionship
	{
		[Key]
		public int ManuChampId { get; set; }
		public int ManuId { get; set; }
		public Manufacturer Manufacturer { get; set; }
		public int Points { get; set; }
	}
}
