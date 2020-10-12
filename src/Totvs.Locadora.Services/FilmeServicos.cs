using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Totvs.Locadora.Core.Models;
using Totvs.Locadora.Infrastructure;

namespace Totvs.Locadora.Services
{
    public class FilmeServicos : RepositorioServicos<Filme>, IFilmeServicos
    {
        public FilmeServicos(DataContext context) : base(context) { }

        public async virtual Task<IEnumerable<Filme>> RetornaPorGenero(string genero)
        {
            return await _context.Set<Filme>()
                    .AsNoTracking()
                    .Where(f => f.Genero == genero)
                    .ToListAsync();
        }

        public async virtual Task<int> RetornaQtdPorGenero(string genero)
        {
            var filmes = await RetornaPorGenero(genero);
            return filmes.Count();
        }
    }
}
