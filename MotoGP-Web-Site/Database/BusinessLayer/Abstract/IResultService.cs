using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
	public interface IResultService:IGenericService<Result>
	{
		public List<Result> GetDriversWithEveryProp();
		public List<Track> GetTracks();
		public List<Session> GetSessions();
		public List<int> GetYears();
	}
}
