
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
			throw new NotImplementedException();
		}

		public Result GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Result> GetDriversWithEveryProp()
		{
			return resultDal.GetDriversWithEveryProp();
        }

		public List<Session> GetSessions()
        {
            using (var c = new Context())
            {
                var sessions = c.Results.Include(x => x.SessionTrack.Session).Select(x => x.SessionTrack.Session).Distinct().ToList();
                return sessions;
            }
        }

		public List<Track> GetTracks()
		{
			using(var c = new Context())
			{
				var tracks = c.Results.Include(x => x.SessionTrack.Track).Select(x => x.SessionTrack.Track).Distinct().ToList();
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
			throw new NotImplementedException();
		}

		public void TRemove(Result entity)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Result entity)
		{
			throw new NotImplementedException();
		}
	}
}
