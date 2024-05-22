using CatalogService.Domain.Aggregates;

namespace Contracts
{
    public record BookReservedEvent(Guid BookId,
            string title,
            string author,
            Genre bookGenre,
            bool isAvailable,
            Condition bookCondition);
    
}
