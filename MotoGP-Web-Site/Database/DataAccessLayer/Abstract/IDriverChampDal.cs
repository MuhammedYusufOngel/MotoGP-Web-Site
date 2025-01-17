﻿using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface IDriverChampDal : IGenericDal<DriverChampionship>
    {
		List<DriverChampionship> GetDriversWithName();
		List<DriverChampionship> GetThreeDriversForHome();
        DriverChampionship GetByIdWithDriver(int id);
    }
}
