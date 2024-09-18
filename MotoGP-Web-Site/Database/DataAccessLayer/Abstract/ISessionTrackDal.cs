using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
    public interface ISessionTrackDal:IGenericDal<SessionTrack>
    {
        List<int> GetYears();
        int GetId(int trackid, int sessionid, int yearid);
        List<SessionTrack> GetSessionTracksWithProperties(int yearid);
    }
}
