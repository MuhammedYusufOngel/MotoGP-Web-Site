using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface INewsService:IGenericService<News>
    {
        public List<News> getSixNewsForHome();
    }
}
