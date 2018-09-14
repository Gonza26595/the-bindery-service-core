using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBindery.Domain.Repositories;

namespace TheBindery.Infrastructure.EFCore.SqlServer
{
    public class RepositoryContext : IRepositoryContext
    {
        private readonly TheBinderyDataContext _context;
        private bool _disposed = false;

        public RepositoryContext(TheBinderyDataContext context)
        {
            _context = context;
        }

        internal TheBinderyDataContext CreateDataContext()
        {
            return _context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;

        }

    }
}
