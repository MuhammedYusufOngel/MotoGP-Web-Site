using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface IResultDal:IGenericDal<Result>
	{
		List<Result> GetDriversWithEveryProp();
		List<Session> GetSessionsByTrackId(int trackid);
		List<Result> GetDriversWithEveryPropByTrackAndSessionId(int trackid, int sessionid);
    }
}
