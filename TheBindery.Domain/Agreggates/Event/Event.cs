using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates.Event
{
    public class Event : TheBinderyContent
    {
        public Event(string title, string contentParagraph,int position) : base(title, contentParagraph,position)
        {
        }





        private Event() { }
    }
}
