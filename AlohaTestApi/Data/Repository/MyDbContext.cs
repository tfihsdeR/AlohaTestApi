using AlohaTestApi.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AlohaTestApi.Data.Repository
{
    public class MyDbContext : DbContext
    {



        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Univercity> Univercities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=AlohaTestDB;trusted_connection=true");
        }
    }
}
