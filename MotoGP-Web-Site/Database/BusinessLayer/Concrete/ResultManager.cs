
using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
	public class ResultManager : IResultService
	{
		private IResultDal resultDal;

		public ResultManager(IResultDal resultDal)
		{
			this.resultDal = resultDal;
		}

		public List<Result> GetAll()
		{
			return resultDal.GetAll();
		}

		public Result GetById(int id)
		{
			return resultDal.getById(id);
		}

		public List<Result> GetDriversWithEveryProp()
		{
			return resultDal.GetDriversWithEveryProp();
        }

		public List<Result> GetDriversWithEveryPropByTrackAndSession(int trackid, int sessionid)
		{
			return resultDal.GetDriversWithEveryPropByTrackAndSessionId(trackid, sessionid);
		}

		public int GetFinalTrackId()
        {
            using (var c = new Context())
            {
                var trackId = c.Results.Include(x => x.SessionTrack.Track).OrderBy(x => x.Id).Select(x => x.SessionTrack.Track.TrackId).FirstOrDefault();
                return (trackId+1);
            }
        }

		public int GetSecondManuId()
        {
            using (var c = new Context())
            {
                var trackId = c.Results.Include(x => x.SessionTrack.Session).OrderBy(x => x.Id).Select(x => x.SessionTrack.Track.TrackId).FirstOrDefault();
                return (trackId + 1);
            }
        }

		public List<Session> GetSessions()
        {
            using (var c = new Context())
            {
                var sessions = c.Results.Include(x => x.SessionTrack.Session).Select(x => x.SessionTrack.Session).Distinct().ToList();
                return sessions;
            }
        }

		public List<Session> GetSessionsByTrackId(int trackid)
		{
			return resultDal.GetSessionsByTrackId(trackid);
		}

		public List<Track> GetTracks()
		{
			using(var c = new Context())
			{
				var tracks = c.Results.Include(x => x.SessionTrack.Track).Include(x => x.SessionTrack.Track.National).Select(x => x.SessionTrack.Track).Distinct().ToList();
				return tracks;
			}
		}

		public List<int> GetYears()
        {
            using (var c = new Context())
            {
                var tracks = c.Results.Include(x => x.SessionTrack.Track).Select(x => x.SessionTrack.Year).Distinct().ToList();
                return tracks;
            }
        }

		public void TAdd(Result entity)
		{
			resultDal.Add(entity);
		}

		public void TRemove(Result entity)
		{
			resultDal.Delete(entity);
		}

		public void TUpdate(Result entity)
		{
			resultDal.Update(entity);
		}
	}
}
