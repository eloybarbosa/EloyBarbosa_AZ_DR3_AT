using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiAmigo.Domain;
using WebApiAmigo.Resources.AmigoResource;

namespace WebApiAmigo.Data
{
    public class WebApiAmigoContext : DbContext
    {
        public WebApiAmigoContext (DbContextOptions<WebApiAmigoContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().ToTable("Pais");
        }

        public DbSet<Amigo> Amigos { get; set; }

        public DbSet<Pais> Paises { get; set; }

        //public DbSet<AmigoResponse> AmigoResponse { get; set; }
    }
}
