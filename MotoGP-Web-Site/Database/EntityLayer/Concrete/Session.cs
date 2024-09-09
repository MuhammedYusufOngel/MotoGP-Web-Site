using System.ComponentModel.DataAnnotations;

namespace MotoGP_Web_Site.Database.EntityLayer.Concrete
{
	public class Session
	{
		[Key]
		public int SessionId { get; set; }
		public string SessionName { get; set; }
		public TimeSpan SessionLength { get; set; }
	}
}
