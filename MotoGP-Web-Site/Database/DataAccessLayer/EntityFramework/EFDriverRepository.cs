using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFDriverRepository : GenericRepository<Driver>, IDriverDal
	{
		public List<Driver> GetDriversWithNational()
		{
			using(var c = new Context())
			{
				var drivers = c.Drivers.Include(x => x.National).ToList();
				return drivers;
			}
		}
	}
}
