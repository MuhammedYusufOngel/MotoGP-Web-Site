using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;
using System.Reflection.Metadata.Ecma335;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KB4N4TR;database=CoreMotoDb;integrated security=true;");
            //base.OnConfiguring(optionsBuilder);
            //server=DESKTOP-KB4N4TR;database=CoreMotoDb;integrated security=true
            //workstation id=CoreMotoDb.mssql.somee.com;packet size=4096;user id=Mete54_SQLLogin_1;pwd=m5g8lglzw9;data source=CoreMotoDb.mssql.somee.com;persist security info=False;initial catalog=CoreMotoDb;TrustServerCertificate=True;
            //server=sql.bsite.net\MSSQL2016;database=meteonder_CoreBlogDb;integrated security=true
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<DriverChampionship> DriverChamps { get; set; }
        public DbSet<TeamChampionship> TeamChamps { get; set; }
        public DbSet<ManuChampionship> ManuChamps { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<SessionTrack> SessionTracks { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Year> Years { get; set; }
    }
}
