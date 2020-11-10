using MediatR;
using Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.CreatePrimeCounter
{
    public class CreatePrimeCounterCommandHandler : IRequestHandler<CreatePrimeCounterCommand, bool>
    {
        private IPrimeCounterDatabase _primeCounterDatabase;

        public CreatePrimeCounterCommandHandler(
            IPrimeCounterDatabase primeCounterDatabase
            )
        {
            _primeCounterDatabase = primeCounterDatabase;
        }

        public async Task<bool> Handle(CreatePrimeCounterCommand request, CancellationToken cancellationToken)
        {
            var result = _primeCounterDatabase.AddPrimeCounter(request.Name, 2);

            return result;
        }
    }
}
