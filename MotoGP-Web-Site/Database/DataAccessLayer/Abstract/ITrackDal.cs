﻿using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Abstract
{
	public interface ITrackDal : IGenericDal<Track>
    {
		List<Track> GetTracksWithNation();
	}
}
