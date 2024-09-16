using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface ITeamDal : IGenericDal<Team>
    {
		List<Team> GetAllWithManufacturer();
		Team GetByIdWithManufacturer(int id);
	}
}
