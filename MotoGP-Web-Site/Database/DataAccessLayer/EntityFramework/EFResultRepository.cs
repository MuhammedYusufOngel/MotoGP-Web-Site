using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFResultRepository : GenericRepository<Result>, IResultDal
	{
		public Result GetByIdWithYear(int id)
		{
            using (var c = new Context())
            {
                var value = c.Results
                    .Include(x => x.SessionTrack)
                    .Include(x => x.SessionTrack.Year)
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                return value;
            }
        }

		public List<Result> GetDriversWithEveryProp()
		{
			using(var c = new Context())
			{
				var values = c.Results
					.Include(x => x.DriverChamp)
					.Include(x => x.DriverChamp.Team)
					.Include(x => x.DriverChamp.Driver)
					.Include(x => x.DriverChamp.Driver.National)
					.Include(x => x.SessionTrack)
					.Include(x => x.SessionTrack.Track)
					.Include(x => x.SessionTrack.Session)
					.OrderBy(x => x.Time).ToList();
				return values;
			}
		}

		public List<Result> GetDriversWithEveryPropByTrackAndSessionId(int trackid, int sessionid, int yearid)
		{
            using (var c = new Context())
            {
                var values = c.Results
                    .Include(x => x.DriverChamp)
                    .Include(x => x.DriverChamp.Team)
                    .Include(x => x.DriverChamp.Driver)
                    .Include(x => x.DriverChamp.Driver.National)
                    .Include(x => x.SessionTrack)
                    .Include(x => x.SessionTrack.Track)
                    .Include(x => x.SessionTrack.Session)
                    .Where(x => x.SessionTrack.Session.SessionId == sessionid && x.SessionTrack.Track.TrackId == trackid && x.SessionTrack.YearId == yearid).OrderBy(x => x.Time).ToList();
                return values;
            }
        }

		public List<Session> GetSessionsByTrackId(int trackid, int yearid)
        {
            using (var c = new Context())
            {
                var values = c.SessionTracks.Include(x => x.Track).Include(x => x.Session).Where(x => x.Track.TrackId == trackid && x.YearId == yearid).Select(x => x.Session).ToList();
                return values;
            }
        }
	}
}
