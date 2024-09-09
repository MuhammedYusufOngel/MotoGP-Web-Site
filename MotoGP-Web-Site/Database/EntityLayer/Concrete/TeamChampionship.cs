using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class TeamChampionship
	{
		[Key]
		public int TeamChampId { get; set; }
		public int TeamId { get; set; }
		public Team Team { get; set; }
		public int Points { get; set; }
	}
}
