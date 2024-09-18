using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
	public interface IResultService:IGenericService<Result>
	{
		public List<Result> GetDriversWithEveryProp();
		public List<Track> GetTracks();
		public List<Session> GetSessions();
		public int GetFinalTrackId();
		public int GetSecondManuId();
		public List<Session> GetSessionsByTrackId(int trackid, int yearid);
		public List<Result> GetDriversWithEveryPropByTrackAndSession(int trackid, int sessionid, int yearid);
		public Result GetByIdWithYear(int id);
    }
}
