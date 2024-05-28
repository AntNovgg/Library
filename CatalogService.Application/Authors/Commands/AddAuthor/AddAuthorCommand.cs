
using MediatR;



namespace CatalogService.Application.Authors.Commands.AddAuthor
{
    public class AddAuthorCommand : IRequest<Guid>
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
    }
}
