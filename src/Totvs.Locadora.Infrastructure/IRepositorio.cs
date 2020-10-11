using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Locadora.Core.Models;

namespace Totvs.Locadora.Infrastructure
{
    public interface IRepositorio<T> : IDisposable where T : Entity
    {
        Task<bool> Insere(T entity);
        Task<bool> Atualiza(T entity);
        Task<bool> Remove(int id);
        Task<T> RetornaPorId(int id);
        Task<IEnumerable<T>> RetornaTodos();
    }
}
