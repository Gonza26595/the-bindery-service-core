using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Domain.Agreggates.News
{
    public class News : TheBinderyContent
    {
        public News(string title, string contentParagraph,int position) : base(title, contentParagraph,position)
        {
        }

        public DateTime? NewsDate { get; set; }
        public string Author { get; set; }
        public string Section { get; set; }



        private News() { }
    }
}
