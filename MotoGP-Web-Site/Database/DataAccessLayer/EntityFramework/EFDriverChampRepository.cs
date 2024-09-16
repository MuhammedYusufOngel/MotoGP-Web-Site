using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFDriverChampRepository : GenericRepository<DriverChampionship>, IDriverChampDal
	{
		public DriverChampionship GetByIdWithDriver(int id)
        {
            using (var c = new Context())
            {
                var driver = c.DriverChamps
                    .Where(x => x.DriverChampId == id).FirstOrDefault();
                return driver;
            }
        }

		public List<DriverChampionship> GetDriversWithName()
		{
			using(var c = new Context())
			{
				var drivers = c.DriverChamps.Include(x => x.Driver).Include(x => x.Team).Include(x => x.Driver.National).OrderByDescending(x => x.Points).ToList();
				return drivers;
			}
		}

		public List<DriverChampionship> GetThreeDriversForHome()
        {
            using (var c = new Context())
            {
                var drivers = c.DriverChamps.Include(x => x.Driver).Include(x=>x.Team).Include(x => x.Driver.National).OrderByDescending(x => x.Points).Take(3).ToList();
                return drivers;
            }
        }
	}
}
