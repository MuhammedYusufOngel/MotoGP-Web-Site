using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface ITeamChampDal : IGenericDal<TeamChampionship>
    {
		List<TeamChampionship> GetTeamsWithName();
		TeamChampionship GetByIdWithTeams(int id);

    }
}
