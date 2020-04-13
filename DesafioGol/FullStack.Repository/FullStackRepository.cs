using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStack.Domain.Model;
using FullStack.Repository.Interface;
using FullStackGol.Repository.DataContext;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Repository
{
    public class FullStackRepository : IFullstackRepository
    {
        private readonly FullStackContext _fullStackContext;
        public FullStackRepository(FullStackContext fullStackContext)
        {
            _fullStackContext = fullStackContext;
        }
        public void Add<T>(T entity) where T : class
        {
            _fullStackContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _fullStackContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _fullStackContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _fullStackContext.SaveChangesAsync()) > 0;
        }

        public async Task<Passagem> GetAllPassagemAsyncId(int IdPassagem)
        {
            IQueryable<Passagem> query = _fullStackContext.Passagens;

            query = query.OrderByDescending(c => c.HoraPartida)
                         .Where(c => c.PassagemId == IdPassagem);

            return (await query.FirstOrDefaultAsync());            
        }       

        public async Task<Passagem[]> GetAllPassagemAsync()
        {
            return await _fullStackContext.Passagens.OrderBy(o => o.DataPartida).ToArrayAsync();
        }
    }
}