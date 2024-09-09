using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using System.Linq.Expressions;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		Context c = new Context();
        public void Add(T item)
        {
            c.Add(item);
            c.SaveChanges();
        }

        public void Delete(T item)
        {
            c.Remove(item);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            return c.Set<T>().ToList();
        }

        public T getById(int id)
        {
            return c.Set<T>().Find(id);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return c.Set<T>().Where(filter).ToList();
        }

        public void Update(T item)
        {
            c.Update(item);
            c.SaveChanges();
        }
    }
}
