using GameHub.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameHub.API.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Jogo> Jogos { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameHub;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jogo>().HasKey(j => j.Id);
        }
    }
}
