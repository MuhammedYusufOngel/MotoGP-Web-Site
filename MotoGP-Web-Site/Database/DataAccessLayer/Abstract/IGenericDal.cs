using System.Linq.Expressions;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T getById(int id);

        List<T> GetAll(Expression<Func<T, bool>> filter);
    }
}
