namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TRemove(T entity);
        void TUpdate(T entity);
        List<T> GetAll();
        T GetById(int id);
    }
}
