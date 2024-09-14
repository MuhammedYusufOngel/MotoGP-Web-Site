using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class TeamChampManager : ITeamChampService
    {
        private ITeamChampDal teamChampDal;

        public TeamChampManager(ITeamChampDal teamChampDal)
        {
            this.teamChampDal = teamChampDal;
        }

        public List<TeamChampionship> GetAll()
        {
            return teamChampDal.GetAll();
        }

        public TeamChampionship GetById(int id)
        {
            return teamChampDal.getById(id);
        }

        public List<TeamChampionship> GetTeamsWithName()
        {
            using(var c = new Context())
            {
                return c.TeamChamps.Include(x => x.Team).Include(x => x.Team.Manufacturer).OrderByDescending(x => x.Points).ToList();
            }
        }

        public void TAdd(TeamChampionship entity)
        {
            teamChampDal.Add(entity);
        }

        public void TRemove(TeamChampionship entity)
        {
            teamChampDal.Delete(entity);
        }

        public void TUpdate(TeamChampionship entity)
        {
            teamChampDal.Update(entity);
        }
    }
}
