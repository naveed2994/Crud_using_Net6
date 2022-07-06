using MediatR;
namespace Application.Customers.CommandHandlers
{
    public class DeleteCommand : IRequest<bool>
    {
        public DeleteCommand(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; }
    }
}
