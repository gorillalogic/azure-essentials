using System;
using System.Collections.Generic;

namespace session_02_api.Data.Model
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
