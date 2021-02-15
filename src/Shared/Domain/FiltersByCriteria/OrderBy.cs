using Shared.Domain.ValueObject;

namespace Shared.Domain.FiltersByCriteria
{
    public class OrderBy : StringValueObject
    {
        public OrderBy(string value) : base(value)
        {
        }
    }
}
