using Microsoft.EntityFrameworkCore;
using Alvarado_Parcial1_AP2.Models;

namespace Alvarado_Parcial1_AP2.DAL{
    public class Contexto : DbContext{
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/Productos.db");
        }
    }
}