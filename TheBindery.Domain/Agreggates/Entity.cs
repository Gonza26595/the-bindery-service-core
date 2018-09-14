using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates
{
    public abstract class Entity
    {
        public int Id { get; private set; }
    }
}
