using System;
using System.Linq;
using session_02_api.Data.Model;

namespace session_02_api.Data.Extensions
{
    public static class AuthorExtensions
    {
        public static IQueryable<Author> GetAll(this IQueryable<Author> query)
        {
            return query;
        }

        public static IQueryable<Author> ById(this IQueryable<Author> query, int id)
        {
            return query.Where(x => x.Id == id);
        }

        public static void Update(this Author target, Author source)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
        }
    }
}
