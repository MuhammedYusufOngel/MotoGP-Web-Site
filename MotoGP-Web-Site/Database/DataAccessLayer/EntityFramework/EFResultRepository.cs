using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFResultRepository : GenericRepository<Result>, IResultDal
	{
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
	}
}
