using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface ITrackService : IGenericService<Track>
    {
        public List<Track> GetTracksWithNation();
        public Track GetByIdWithNation(int id);
    }
}
