using System.Collections.Generic;
using System.Threading.Tasks;
using FullStack.Domain.Model;

namespace FullStack.Repository.Interface
{
    public interface IFullstackRepository
    {
        //Geral
         void Add<T>(T entity) where T: class;

         void Update<T>(T entity) where T: class;

         void Delete<T>(T entity) where T: class;

        //Passagens
        Task<Passagem[]> GetAllPassagemAsync();

        Task<Passagem> GetAllPassagemAsyncId(int PassagemId);

        Task<bool> SaveChangesAsync();
    }
}