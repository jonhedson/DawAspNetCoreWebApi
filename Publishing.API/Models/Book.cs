using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publishing.API.Models
{
    public class Book
    {
        public int BookId { get; set; }

        public string Isbn { get; set; }

        public string Title { get; set; }

        public IList<BookAuthor> BookAuthor { get; set; }
    }
}
