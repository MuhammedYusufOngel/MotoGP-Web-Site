using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class ManuChampionship
	{
		[Key]
		public int ManuChampId { get; set; }
		public int ManufacturerManuId { get; set; }
        public int ManuId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int Points { get; set; }
        public int? YearId { get; set; }
        public Year? Year { get; set; }
        public bool? isAdd { get; set; }
	}
}
