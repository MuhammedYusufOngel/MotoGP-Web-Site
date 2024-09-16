using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFTeamRepository : GenericRepository<Team>, ITeamDal
	{
		public List<Team> GetAllWithManufacturer()
		{
			using(var c =new Context())
			{
				var teams = c.Teams.Include(x => x.Manufacturer).ToList();
				return teams;
			}
		}

		public Team GetByIdWithManufacturer(int id)
		{
			using (var c = new Context())
			{
				var team = c.Teams.Include(x => x.Manufacturer).Where(x => x.TeamId == id).FirstOrDefault();
				return team;
			}
		}
	}
}
