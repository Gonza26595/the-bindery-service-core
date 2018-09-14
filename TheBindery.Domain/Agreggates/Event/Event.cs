using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates.Event
{
    public class Event : TheBinderyContent
    {
        public Event(string title, string contentParagraph) : base(title, contentParagraph)
        {
        }





        private Event() { }
    }
}
