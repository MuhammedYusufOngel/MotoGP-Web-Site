﻿using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.BusinessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Abstract;
using MotoGP_Web_Site.Database.DataAccessLayer.Concrete;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Concrete
{
    public class ManuChampManager : IManuChampService
    {
        private IManuChampDal manuChampDal;

        public ManuChampManager(IManuChampDal manuChampDal)
        {
            this.manuChampDal = manuChampDal;
        }

        public List<ManuChampionship> GetAll()
        {
            return manuChampDal.GetAll();
        }

        public ManuChampionship GetById(int id)
        {
            return manuChampDal.getById(id);
        }

        public List<ManuChampionship> GetManusWithName()
        {
            using (var c = new Context())
                return c.ManuChamps.Include(x => x.Manufacturer).OrderByDescending(x => x.Points).ToList();
        }

        public void TAdd(ManuChampionship entity)
        {
            manuChampDal.Add(entity);
        }

        public void TRemove(ManuChampionship entity)
        {
            manuChampDal.Delete(entity);
        }

        public void TUpdate(ManuChampionship entity)
        {
            manuChampDal.Update(entity);
        }
    }
}