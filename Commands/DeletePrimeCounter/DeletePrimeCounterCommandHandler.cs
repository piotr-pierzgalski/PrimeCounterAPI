using MediatR;
using Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.DeletePrimeCounter
{
    public class DeletePrimeCounterCommandHandler : IRequestHandler<DeletePrimeCounterCommand, bool>
    {
        private IPrimeCounterDatabase _primeCounterDatabase;

        public DeletePrimeCounterCommandHandler(
            IPrimeCounterDatabase primeCounterDatabase
            )
        {
            _primeCounterDatabase = primeCounterDatabase;
        }

        public async Task<bool> Handle(DeletePrimeCounterCommand request, CancellationToken cancellationToken)
        {
            var result = _primeCounterDatabase.RemovePrimeCounter(request.Name);

            return result;
        }
    }
}
