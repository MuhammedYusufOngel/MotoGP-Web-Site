using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class SessionTrackManager : ISessionTrackService
    {
        private ISessionTrackDal sessionTrackDal;

        public SessionTrackManager(ISessionTrackDal sessionTrackDal)
        {
            this.sessionTrackDal = sessionTrackDal;
        }

        public List<SessionTrack> GetAll()
        {
            return sessionTrackDal.GetAll();
        }

        public SessionTrack GetById(int id)
        {
            return sessionTrackDal.getById(id);
        }

        public int GetId(int trackid, int sessionid, int yearid)
        {
            return sessionTrackDal.GetId(trackid, sessionid, yearid);
        }

        public List<SessionTrack> GetSessionTracksWithProperties(int yearid)
        {
            return sessionTrackDal.GetSessionTracksWithProperties(yearid);
        }

        public List<int> GetYears()
        {
            return sessionTrackDal.GetYears();
        }

        public void TAdd(SessionTrack entity)
        {
            sessionTrackDal.Add(entity);
        }

        public void TRemove(SessionTrack entity)
        {
            sessionTrackDal.Delete(entity);
        }

        public void TUpdate(SessionTrack entity)
        {
            sessionTrackDal.Update(entity);
        }
    }
}
