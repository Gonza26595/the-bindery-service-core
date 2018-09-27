using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Application.RestApi.ResourceModels.RequestResourceModels
{
    public class NewsRequestResourceModel
    {
        public string Title { get; set; }
        public string ContentParagraph { get; set; }
        public DateTime? NewsDate { get; set; }
        public string Section { get; set; }
        public string Author { get; set; }
        public int Position { get; set; }
    }
}
