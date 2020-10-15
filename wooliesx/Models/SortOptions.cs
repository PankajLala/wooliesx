using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace wooliesx.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortOptions
    {
        Low = 1,
        High = 2,
        Ascending = 3,
        Descending = 4,
        Recommended = 5
    }
}
