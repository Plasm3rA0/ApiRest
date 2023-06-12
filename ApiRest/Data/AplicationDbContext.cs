using ApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRest.Data
{
    public class AplicationDbContext : DbContext
    {

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    name = "Pol",
                    surnames = "Hernan Camino",
                    username = "polhernan",
                    password = "Alumne1234.",
                    email = "phernancamino@insllica.cat",
                    age = 18,
                    imageUrl = "",
                    creationDate = DateTime.Now,
                    updateDate = DateTime.Now
                },
                new User()
                {
                    Id = 2,
                    name = "Veronica",
                    surnames = "Lainez Liso",
                    username = "vero",
                    password = "Alumne1234.",
                    email = "vlainezliso@insllica.cat",
                    age = 18,
                    imageUrl = "",
                    creationDate = DateTime.Now,
                    updateDate = DateTime.Now
                }
                );
                
                
        }

    }
}
