using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class DriverChampManager : IDriverChampService
    {
        private IDriverChampDal driverChampDal;

        public DriverChampManager(IDriverChampDal driverChampDal)
        {
            this.driverChampDal = driverChampDal;
        }

        public List<DriverChampionship> GetAll()
        {
            throw new NotImplementedException();
        }

        public DriverChampionship GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DriverChampionship> GetDriversWithName()
        {
            return driverChampDal.GetDriversWithName();
        }

        public List<DriverChampionship> GetThreeDriversForHome()
        {
            return driverChampDal.GetThreeDriversForHome();
        }

        public void TAdd(DriverChampionship entity)
        {
            throw new NotImplementedException();
        }

        public void TRemove(DriverChampionship entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(DriverChampionship entity)
        {
            throw new NotImplementedException();
        }
    }
}
