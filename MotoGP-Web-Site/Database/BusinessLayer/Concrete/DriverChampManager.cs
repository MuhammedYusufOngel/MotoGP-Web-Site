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
            return driverChampDal.GetAll();
        }

        public DriverChampionship GetById(int id)
        {
            return driverChampDal.getById(id);
        }

        public DriverChampionship GetByIdWithDriver(int id)
        {
            return driverChampDal.GetByIdWithDriver(id);
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
            driverChampDal.Add(entity);
        }

        public void TRemove(DriverChampionship entity)
        {
            driverChampDal.Delete(entity);
        }

        public void TUpdate(DriverChampionship entity)
        {
            driverChampDal.Update(entity);
        }
    }
}
