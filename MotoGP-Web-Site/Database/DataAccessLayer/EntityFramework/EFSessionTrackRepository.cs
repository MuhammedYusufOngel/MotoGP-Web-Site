using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
    public class EFSessionTrackRepository:GenericRepository<SessionTrack>, ISessionTrackDal
    {
        public int GetId(int trackid, int sessionid, int yearid)
        {
            using (var c = new Context())
            {
                var id = c.SessionTracks.Where(x => x.SessionId == sessionid && x.TrackId == trackid && x.YearId == yearid).Select(x => x.Id).FirstOrDefault();
                return id;
            }
        }

        public List<SessionTrack> GetSessionTracksWithProperties(int yearid)
        {
            using (var c = new Context())
            {
                var sessionTracks = c.SessionTracks
                    .Include(x => x.Year)
                    .Include(x => x.Track)
                    .Include(x => x.Session)
                    .Where(x => x.YearId == yearid)
                    .OrderByDescending(x => x.Date).ToList();
                return sessionTracks;
            }
        }

        public List<int> GetYears()
        {
            using (var c = new Context())
            {
                var years = c.SessionTracks.Include(x => x.Year).Select(x => x.Year.YearId).Distinct().ToList();
                return years;
            }
        }
    }
}
