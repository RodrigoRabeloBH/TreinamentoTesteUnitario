using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Locadora.Core.Models;

namespace Totvs.Locadora.Infrastructure
{
    public interface IFilmeServicos : IRepositorio<Filme>
    {
        Task<IEnumerable<Filme>> RetornaPorGenero(string genero);
        Task<int> RetornaQtdPorGenero(string genero);
    }
}
