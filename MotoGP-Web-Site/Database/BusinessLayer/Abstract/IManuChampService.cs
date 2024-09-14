using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface IManuChampService : IGenericService<ManuChampionship>
    {
        public List<ManuChampionship> GetManusWithName();
    }
}
