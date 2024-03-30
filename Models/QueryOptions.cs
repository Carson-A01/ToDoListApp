using System.Linq.Expressions;

namespace ToDoListApp.Models
{
    public class QueryOptions<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; } = null!;
        public Expression<Func<T, bool>> Where { get; set; } = null!;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        private string[] includes = Array.Empty<String>();
        public string Includes { set => includes = value.Replace(" ", "").Split(','); }
        public string[] GetIncludes() => includes;
        public bool HasOrderBy => OrderBy != null;
        public bool HasWhere => Where != null;
        public bool HasPaging => PageNumber > 0 && PageSize > 0;
    }

    public static class QueryExtensions
    {
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
