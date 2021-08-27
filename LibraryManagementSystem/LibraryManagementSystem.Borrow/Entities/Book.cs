using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;

namespace LibraryManagementSystem.Borrow.Entities
{
    public class Book : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public IList<Author> Authors { get; set; }
        public IList<BookAuthor> AllAuthorNames { get; set; }
    }
}
