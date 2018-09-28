using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates
{
    public abstract class TheBinderyContent:Entity, IAggregateRoot
    {

        protected TheBinderyContent(string title, string contentParagraph,int position)
        {
            Title = title;
            ContentParagraph = contentParagraph;
            Position = position;
        }


        public string Title { get; set; }
        public string ContentParagraph { get; set; }
        public int Position { get; set; }


        protected TheBinderyContent() { }
    }
}
