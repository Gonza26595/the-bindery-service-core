using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Agreggates;
using TheBindery.Domain.Repositories;

namespace TheBindery.Infrastructure.EFCore.SqlServer
{
    public abstract class Repository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoot
    {
        private readonly IRepositoryContext _repositoryContext;
        private readonly TheBinderyDataContext _context;

        public Repository(IRepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _context = ((RepositoryContext)repositoryContext).CreateDataContext();
        }

        protected DbSet<TAggregateRoot> GetDbSet()
        {
            return _context.Set<TAggregateRoot>();
        }

        public virtual IQueryable<TAggregateRoot> GetAll()
        {
            return GetDbSet().AsQueryable();
        }

        public virtual TAggregateRoot GetById(int id)
        {
            return GetDbSet().Find(id);
        }

        public virtual async Task<TAggregateRoot> GetByIdAsync(int id)
        {
            return await GetDbSet().FindAsync(id);
        }

        public void Add(TAggregateRoot aggregateRoot)
        {
            GetDbSet().Add(aggregateRoot);
        }

        public void Update(TAggregateRoot aggregateRoot)
        {
            GetDbSet().Attach(aggregateRoot);

            _context.Entry(aggregateRoot).State = EntityState.Modified;
        }

        public void Delete(TAggregateRoot aggregateRoot)
        {

            if (_context.Entry(aggregateRoot).State == EntityState.Detached)
            {
                GetDbSet().Attach(aggregateRoot);
            }

            GetDbSet().Remove(aggregateRoot);

        }

        public IRepositoryContext Context
        {
            get
            {
                return _repositoryContext;
            }
        }
    }
}
