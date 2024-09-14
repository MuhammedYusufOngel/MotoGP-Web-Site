using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
    public interface INewsDal:IGenericDal<News>
    {
        List<News> getSixNewsForHome();
    }
}
