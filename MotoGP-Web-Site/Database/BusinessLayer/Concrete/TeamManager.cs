using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private ITeamDal teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            this.teamDal = teamDal;
        }

        public List<Team> GetAll()
        {
            return teamDal.GetAll();
        }

        public Team GetById(int id)
        {
            return teamDal.getById(id);
        }

        public Team GetByIdWithManufacturer(int id)
        {
            return teamDal.GetByIdWithManufacturer(id);
        }

        public List<Team> GetTeamsWithManufacturer()
        {
            return teamDal.GetAllWithManufacturer();
        }

        public void TAdd(Team entity)
        {
            teamDal.Add(entity);
        }

        public void TRemove(Team entity)
        {
            teamDal.Delete(entity);
        }

        public void TUpdate(Team entity)
        {
            teamDal.Update(entity);
        }
    }
}
