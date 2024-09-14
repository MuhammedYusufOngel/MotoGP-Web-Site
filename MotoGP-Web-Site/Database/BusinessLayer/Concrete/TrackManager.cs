using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class TrackManager : ITrackService
    {
        private ITrackDal trackDal;

        public TrackManager(ITrackDal trackDal)
        {
            this.trackDal = trackDal;
        }

        public List<Track> GetAll()
        {
            return trackDal.GetAll();
        }

        public Track GetById(int id)
        {
            return trackDal.getById(id);
        }

        public List<Track> GetTracksWithNation()
        {
            return trackDal.GetTracksWithNation();
        }

        public void TAdd(Track entity)
        {
            trackDal.Add(entity);
        }

        public void TRemove(Track entity)
        {
            trackDal.Delete(entity);
        }

        public void TUpdate(Track entity)
        {
            trackDal.Update(entity);
        }
    }
}
