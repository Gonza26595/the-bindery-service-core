using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates;

namespace TheBindery.Domain.Repositories
{
    public interface IRepository<T> where T: IAggregateRoot
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        void Add(T aggregateRoot);
        void Update(T aggregateRoot);
        void Delete(T aggregateRoot);
        IRepositoryContext Context { get; }
    }
}
