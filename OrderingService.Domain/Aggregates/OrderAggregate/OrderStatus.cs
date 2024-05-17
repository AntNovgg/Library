using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderingService.Domain.Aggregates.OrderAggregate
{
    ////[JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Active,
        Completed,
        Expired
    }
}
