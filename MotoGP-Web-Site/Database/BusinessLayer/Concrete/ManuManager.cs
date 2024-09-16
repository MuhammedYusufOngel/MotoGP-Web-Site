using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class ManuManager : IManuService
    {
        private IManuDal manuDal;

        public ManuManager(IManuDal manuDal)
        {
            this.manuDal = manuDal;
        }

        public List<Manufacturer> GetAll()
        {
            return manuDal.GetAll();
        }

        public Manufacturer GetById(int id)
        {
            return manuDal.getById(id);
        }

        public void TAdd(Manufacturer entity)
        {
            manuDal.Add(entity);
        }

        public void TRemove(Manufacturer entity)
        {
            manuDal.Delete(entity);
        }

        public void TUpdate(Manufacturer entity)
        {
            manuDal.Update(entity);
        }
    }
}
