using jogoAnimaisAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace jogoAnimaisAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Personagens> personagens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Personagens>().HasData(
                new Personagens { personagemId = 1, personagemNome = "zebra", posicaoPersonagem = "Direita" },
                new Personagens { personagemId = 2, personagemNome = "leão", posicaoPersonagem = "Direita" },
                new Personagens { personagemId = 3, personagemNome = "hipopótamo", posicaoPersonagem = "Direita" },
                new Personagens { personagemId = 4, personagemNome = "guarda", posicaoPersonagem = "Direita" }
                );
        }
    }
}
