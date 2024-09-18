using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class SessionManager : ISessionService
    {
        private ISessionDal sessionDal;

        public SessionManager(ISessionDal sessionDal)
        {
            this.sessionDal = sessionDal;
        }

        public List<Session> GetAll()
        {
            return sessionDal.GetAll();
        }

        public Session GetById(int id)
        {
            return sessionDal.getById(id);
        }

        public void TAdd(Session entity)
        {
            sessionDal.Add(entity);
        }

        public void TRemove(Session entity)
        {
            sessionDal.Delete(entity);
        }

        public void TUpdate(Session entity)
        {
            sessionDal.Update(entity);
        }
    }
}
