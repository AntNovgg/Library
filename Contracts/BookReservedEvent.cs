using CatalogService.Domain.Aggregates;

namespace Contracts
{
    public record BookReservedEvent(Guid bookId, Guid orderId);
    
}
