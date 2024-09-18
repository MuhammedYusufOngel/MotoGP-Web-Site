using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.DataAccessLayer.Repositories;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.EntityFramework
{
    public class EFNewsRepository : GenericRepository<News>, INewsDal
    {
        public List<News> GetRelatedNews()
        {
            using (var c = new Context())
            {
                var values = c.News.OrderByDescending(x => x.Id).Take(6).ToList();
                return values;
            }
        }

        public List<News> getSixNewsForHome()
        {
            using(var c = new Context())
            {
                var values = c.News.OrderByDescending(x => x.Id).Take(6).ToList();
                return values;
            }
        }
    }
}
