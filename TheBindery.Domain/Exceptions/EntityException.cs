using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Exceptions
{
    public class EntityException : Exception
    {
        public virtual string Code { get; }
        public virtual string Field { get; }
    }
}
