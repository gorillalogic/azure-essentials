using System;
using System.Collections.Generic;

namespace session_02_api.Data.Model
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? YearPublished { get; set; }
        public int? AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}
