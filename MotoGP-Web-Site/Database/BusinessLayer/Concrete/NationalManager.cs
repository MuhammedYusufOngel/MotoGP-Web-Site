using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class NationalManager : INationalService
    {
        private INationalDal nationalDal;

        public NationalManager(INationalDal nationalDal)
        {
            this.nationalDal = nationalDal;
        }

        public List<National> GetAll()
        {
            return nationalDal.GetAll();
        }

        public National GetById(int id)
        {
            return nationalDal.getById(id);
        }

        public void TAdd(National entity)
        {
            nationalDal.Add(entity);
        }

        public void TRemove(National entity)
        {
            nationalDal.Delete(entity);
        }

        public void TUpdate(National entity)
        {
            nationalDal.Update(entity);
        }
    }
}
