using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Data;

namespace LibraryManagementSystem.Borrow.Entities
{
    public class Author : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IList<Book> Books { get; set; }
        public IList<BookAuthor> AllBookNames { get; set; }
    }
}
