using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class YearManager : IYearService
    {
        private IYearDal yearDal;

        public YearManager(IYearDal yearDal)
        {
            this.yearDal = yearDal;
        }

        public List<Year> GetAll()
        {
            return yearDal.GetAll();
        }

        public Year GetById(int id)
        {
            return yearDal.getById(id);
        }

        public void TAdd(Year entity)
        {
            yearDal.Add(entity);
        }

        public void TRemove(Year entity)
        {
            yearDal.Delete(entity);
        }

        public void TUpdate(Year entity)
        {
            yearDal.Update(entity);
        }
    }
}
