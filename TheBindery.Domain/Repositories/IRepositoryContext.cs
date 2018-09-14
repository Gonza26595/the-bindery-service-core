using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Repositories
{
    public interface IRepositoryContext : IDisposable
    {
        int Commit();

        Task<int> CommitAsync();

    }
}
