using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates.News
{
    public class News : TheBinderyContent
    {
        public News(string title, string contentParagraph) : base(title, contentParagraph)
        {
        }

        public DateTime? NewsDate { get; set; }
        public string Author { get; set; }
        public string Section { get; set; }
        public int Position { get; set; }



        private News() { }
    }
}
