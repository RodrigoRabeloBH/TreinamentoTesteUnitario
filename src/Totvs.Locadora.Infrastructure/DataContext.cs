using Microsoft.EntityFrameworkCore;
using Totvs.Locadora.Core.Models;
using Totvs.Locadora.Infrastructure.Mapping;

namespace Totvs.Locadora.Infrastructure
{
    public class DataContext : DbContext
    {
        DbSet<Filme> Filmes;

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Totvs.Locadora;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmeMapping());
        }
        public DataContext() { }
    }
}
