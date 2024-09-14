using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class NewsManager : INewsService
    {
        private INewsDal newsDal;

        public NewsManager(INewsDal newsDal)
        {
            this.newsDal = newsDal;
        }

        public List<News> GetAll()
        {
            return newsDal.GetAll();
        }

        public News GetById(int id)
        {
            return newsDal.getById(id);
        }

        public List<News> getSixNewsForHome()
        {
            return newsDal.getSixNewsForHome();
        }

        public void TAdd(News entity)
        {
            newsDal.Add(entity);
        }

        public void TRemove(News entity)
        {
            newsDal.Delete(entity);
        }

        public void TUpdate(News entity)
        {
            newsDal.Update(entity);
        }
    }
}
