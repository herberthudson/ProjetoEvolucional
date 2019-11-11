using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEvolucional.Data
{
    public class DbInitializer
    {
        public static void Init(ProjetoEvolucionalDataContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
