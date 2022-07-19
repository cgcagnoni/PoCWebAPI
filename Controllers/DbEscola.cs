using Microsoft.EntityFrameworkCore;

namespace PoCWebAPI.Models
{
    public class DbEscola : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder Configuracao)
        {
            Configuracao.UseInMemoryDatabase("Escola");
        }
    }
}
