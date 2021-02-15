using System.Collections.Generic;

namespace Shared.Domain.FiltersByCriteria
{
    public class Filter
    {
        public FilterField Field { get; }
        public FilterOperator Operator { get; }
        public FilterValue Value { get; }

        public Filter(FilterField field, FilterOperator @operator, FilterValue value)
        {
            Field = field;
            Operator = @operator;
            Value = value;
        }

        public static Filter FromValues(Dictionary<string, string> values)
        {

            var field = values["field"];
            
            return new Filter(
                new FilterField(values["field"]),
                values["operator"].FilterOperatorFromValue(),
                new FilterValue(values["value"])
            );
        }
    }

    public class FilterParam
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
    }
}