using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFManuChampRepository : GenericRepository<ManuChampionship>, IManuChampDal
	{
		public ManuChampionship GetByIdManufacturerWithName(int id)
		{
			using(var c = new Context())
			{
				var data = c.ManuChamps.Include(x => x.Manufacturer).Where(x => x.ManuChampId == id).FirstOrDefault();
				return data;
			}
		}

		public List<ManuChampionship> GetManusWithName()
        {
            using (var c = new Context())
                return c.ManuChamps.Include(x => x.Manufacturer).Include(x => x.Year).OrderByDescending(x => x.Points).ToList();
        }

		public ManuChampionship MakeActive(int id)
		{
            using (var c = new Context())
			{
				var manu = c.ManuChamps.Where(x => x.ManuChampId == id).FirstOrDefault();
				manu.isAdd = true;
				return manu;
			}
        }

		public ManuChampionship MakePassive(int id)
        {
            using (var c = new Context())
            {
                var manu = c.ManuChamps.Where(x => x.ManuChampId == id).FirstOrDefault();
                manu.isAdd = false;
                return manu;
            }
        }
	}
}
