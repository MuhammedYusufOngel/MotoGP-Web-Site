using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFTrackRepository : GenericRepository<Track>, ITrackDal
	{
		public Track GetByIdWithNation(int id)
        {
            using (var c = new Context())
            {
                var track = c.Tracks.Include(x => x.National).Where(x => x.TrackId == id).FirstOrDefault();
				return track;
            }
        }

		public List<Track> GetTracksWithNation()
		{
			using(var c = new Context())
			{
				return c.Tracks.Include(x => x.National).ToList();
			}
		}
	}
}
