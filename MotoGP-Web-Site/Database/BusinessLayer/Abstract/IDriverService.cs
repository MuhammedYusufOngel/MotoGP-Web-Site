﻿using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface IDriverService:IGenericService<Driver>
    {
        public List<Driver> GetDriversWithNational();
    }
}
