using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjetoEvolucional.Models;

namespace ProjetoEvolucional.Data
{
    public class ProjetoEvolucionalDataContext: DbContext
    {
        private readonly IConfiguration _config;

        public ProjetoEvolucionalDataContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("ProjetoEvolucionalConn"));
        }

        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Avaliacao> Avalicaoes { get; set; }

        public DbSet<Disciplina> Disciplinas { get; set; }
    }
}
