using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotoGP_Web_Site.Database.EntityLayer.Concrete;

namespace MotoGP_Web_Site.Database.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser, AppRole, int>
	{
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-KB4N4TR;database=CoreMotoDb;integrated security=true;");
            //base.OnConfiguring(optionsBuilder);
            //server=DESKTOP-KB4N4TR;database=CoreBlogDb;integrated security=true
            //workstation id=CoreBlogDb.mssql.somee.com;packet size=4096;user id=IcemanStanley_SQLLogin_1;pwd=pnt6gpceyi;data source=CoreBlogDb.mssql.somee.com;persist security info=False;initial catalog=CoreBlogDb;TrustServerCertificate=True;
            //server=sql.bsite.net\MSSQL2016;database=meteonder_CoreBlogDb;integrated security=true
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<DriverChampionship> DriverChamps { get; set; }
        public DbSet<TeamChampionship> TeamChamps { get; set; }
        public DbSet<ManuChampionship> ManuChamps { get; set; }
    }
}
