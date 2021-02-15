using Shared.Domain.ValueObject;

namespace Shared.Domain.FiltersByCriteria
{
    public class FilterValue : StringValueObject
    {
        public FilterValue(string value) : base(value)
        {
        }
    }
}
