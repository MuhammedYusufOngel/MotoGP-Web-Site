﻿using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.BusinessLayer.Abstract
{
    public interface ITeamService : IGenericService<Team>
    {
        public List<Team> GetTeamsWithManufacturer();
        public Team GetByIdWithManufacturer(int id);
    }
}
