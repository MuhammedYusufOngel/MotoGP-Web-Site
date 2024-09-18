using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface ISessionTrackService:IGenericService<SessionTrack>
    {
        public List<int> GetYears();
        public int GetId(int trackid, int sessionid, int yearid);
        public List<SessionTrack> GetSessionTracksWithProperties(int yearid);
    }
}
