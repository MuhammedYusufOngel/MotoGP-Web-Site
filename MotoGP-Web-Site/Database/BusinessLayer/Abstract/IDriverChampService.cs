using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface IDriverChampService:IGenericService<DriverChampionship>
    {
        public List<DriverChampionship> GetDriversWithName();
        public List<DriverChampionship> GetThreeDriversForHome();
    }
}
