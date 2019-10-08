using System.Linq;
using session_02_api.Data.Model;

namespace session_02_api.Data.Extensions
{
    public static class BookExtensions
    {
        public static IQueryable<Book> GetAll(this IQueryable<Book> query)
        {
            return query;
        }

        public static IQueryable<Book> ById(this IQueryable<Book> query, int id)
        {
            return query.Where(x => x.Id == id);
        }

        public static void Update(this Book target, Book source)
        {
            target.AuthorId = source.AuthorId;
            target.Title = source.Title;
            target.YearPublished = source.YearPublished;
        }
    }
}
