using MediatR;
using OrderingService.Domain.Aggregates.RenterAggregate;
using OrderingService.Domain.Seeds;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Application.Orders.Queries.GetOrderListBySpec
{
    public class GetOrderListBySpecQuery : IRequest<OrderListBySpecDto>
    {
        public string? BookTittle;
        public FullName AuthorFullName;
        public DateTimeOffset PlannedDate1;
        public DateTimeOffset PlannedDate2;
        public DateTimeOffset OrderDate1;
        public DateTimeOffset OrderDate2;
        public bool BookTittleSpec;
        public bool BookAuthorSpec;
        public bool PlannedReturnDateSpec;
        public bool OrderDateSpec;

        public GetOrderListBySpecQuery(string? bookTittle,
            FullName authorFullName,
            DateTimeOffset plannedDate1,
            DateTimeOffset plannedDate2,
            DateTimeOffset orderDate1,
            DateTimeOffset orderDate2,
            bool bookTittleSpec,
            bool bookAuthorSpec, 
            bool plannedReturnDateSpec,
            bool orderDateSpec)
        {
            BookTittle = bookTittle;
            AuthorFullName = authorFullName;
            PlannedDate1 = plannedDate1;
            PlannedDate2 = plannedDate2;
            OrderDate1 = orderDate1;
            OrderDate2 = orderDate2;
            BookTittleSpec = bookTittleSpec;
            BookAuthorSpec = bookAuthorSpec;
            PlannedReturnDateSpec = plannedReturnDateSpec;
            OrderDateSpec = orderDateSpec;            
        }
    }
}
