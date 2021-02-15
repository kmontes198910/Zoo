using System.Collections.Generic;
using System.Linq;

namespace Shared.Domain.FiltersByCriteria
{
    public class Filters
    {
        public List<Filter> Values { get; }

        public Filters(List<Filter> filters)
        {
            Values = filters;
        }

        public static Filters FromValues(List<Dictionary<string, string>> filters)
        {
            if (filters == null) return null;

            var list = filters.Select(Filter.FromValues).ToList();
            return new Filters(list);
        }
    }
}
