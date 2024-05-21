namespace Contracts
{
    public record BookReservedEvent(int BookId,
            string title,
            string author,
            int bookGenre,
            bool isAvailable,
            int bookCondition);
    
}
