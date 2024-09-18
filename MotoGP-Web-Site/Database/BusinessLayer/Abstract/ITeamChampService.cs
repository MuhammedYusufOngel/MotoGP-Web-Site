using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface ITeamChampService : IGenericService<TeamChampionship>
    {
        public List<TeamChampionship> GetTeamsWithName();
        public TeamChampionship GetByIdWithTeams(int id);
    }
}
