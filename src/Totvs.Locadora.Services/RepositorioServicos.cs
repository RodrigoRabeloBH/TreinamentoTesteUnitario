using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Locadora.Core.Models;
using Totvs.Locadora.Infrastructure;

namespace Totvs.Locadora.Services
{
    public abstract class RepositorioServicos<T> : IRepositorio<T> where T : Entity
    {
        protected DataContext _context;

        protected RepositorioServicos(DataContext context)
        {
            _context = context;
        }

        public virtual async Task<bool> Atualiza(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new AggregateException($"Não foi póssível realizar a atualização. Motivo:{ex.Message}");
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public virtual async Task Insere(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Não foi possivel realizar a inserção. Motivo: {ex.Message}");
            }
        }

        public virtual async Task<bool> Remove(int id)
        {
            try
            {
                _context.Set<T>().Remove(await RetornaPorId(id));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Não foi possivel remover a entidade. Motivo: {ex.Message}");
            }
        }

        public virtual async Task<T> RetornaPorId(int id)
        {
            try
            {
                return await _context.Set<T>()
                  .AsNoTracking()
                  .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<IEnumerable<T>> RetornaTodos()
        {
            try
            {
                return await _context.Set<T>()
                   .AsNoTracking()
                   .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
