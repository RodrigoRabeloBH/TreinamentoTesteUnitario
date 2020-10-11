using Totvs.Locadora.Core.Models;
using Totvs.Locadora.Infrastructure;

namespace Totvs.Locadora.Services
{
    public class FilmeServicos : RepositorioServicos<Filme>, IFilmeServicos
    {
        public FilmeServicos(DataContext context) : base(context) { }
    }
}
