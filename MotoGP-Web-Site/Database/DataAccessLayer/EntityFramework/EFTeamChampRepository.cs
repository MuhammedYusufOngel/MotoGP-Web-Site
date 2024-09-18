using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
	public class EFTeamChampRepository : GenericRepository<TeamChampionship>, ITeamChampDal
	{
        public TeamChampionship GetByIdWithTeams(int id)
        {
            using (var c = new Context())
            {
                var data = c.TeamChamps
                    .Include(x => x.Team)
                    .Include(x => x.Team.Manufacturer)
                    .Where(x => x.TeamChampId == id).FirstOrDefault();
                return data;
            }
        }

        public List<TeamChampionship> GetTeamsWithName()
        {
            using (var c = new Context())
            {
                return c.TeamChamps.Include(x => x.Team).Include(x => x.Team.Manufacturer).Include(x=> x.Year).OrderByDescending(x => x.Points).ToList();
            }
        }
	}
}
