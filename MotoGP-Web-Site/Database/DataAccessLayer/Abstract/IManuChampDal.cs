using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface IManuChampDal:IGenericDal<ManuChampionship>
	{
		ManuChampionship GetByIdManufacturerWithName(int id);
		List<ManuChampionship> GetManusWithName();
        ManuChampionship MakePassive(int id);
        ManuChampionship MakeActive(int id);
    }
}
