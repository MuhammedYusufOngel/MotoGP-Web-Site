using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class DriverManager : IDriverService
    {
        private IDriverDal driverDal;

        public DriverManager(IDriverDal driverDal)
        {
            this.driverDal = driverDal;
        }

        public List<Driver> GetAll()
        {
            return driverDal.GetAll();
        }

        public Driver GetById(int id)
        {
            return driverDal.getById(id);
        }

        public List<Driver> GetDriversWithNational()
        {
            return driverDal.GetDriversWithNational();
        }

        public void TAdd(Driver entity)
        {
            driverDal.Add(entity);
        }

        public void TRemove(Driver entity)
        {
            driverDal.Delete(entity);
        }

        public void TUpdate(Driver entity)
        {
            driverDal.Update(entity);
        }
    }
}
