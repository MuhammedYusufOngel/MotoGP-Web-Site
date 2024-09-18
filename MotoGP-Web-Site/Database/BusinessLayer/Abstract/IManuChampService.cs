using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface IManuChampService : IGenericService<ManuChampionship>
    {
        public List<ManuChampionship> GetManusWithName();
        public ManuChampionship GetByIdManufacturerWithName(int id);
        public ManuChampionship MakePassive(int id);
        public ManuChampionship MakeActive(int id);
    }
}
