using System.Linq;

namespace ProjetoEvolucional.Data
{
    public class DbInitializer
    {
        public static void Init(ProjetoEvolucionalDataContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Models.Usuario
                {
                    Nome = "Candidato Evolucional",
                    Login = "candidato-evolucional",
                    Senha = "123456"
                });

                context.SaveChanges();
            }
        }
    }
}
