using MediatR;
using Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.IncrementPrimeCounter
{
    public class IncrementPrimeCounterCommandHandler : IRequestHandler<IncrementPrimeCounterCommand, bool>
    {
        private IPrimeCounterDatabase _primeCounterDatabase;
        private IPrimeNumberDatabase _primeNumberDatabase;

        public IncrementPrimeCounterCommandHandler(
            IPrimeCounterDatabase primeCounterDatabase,
            IPrimeNumberDatabase primeNumberDatabase
            )
        {
            _primeCounterDatabase = primeCounterDatabase;
            _primeNumberDatabase = primeNumberDatabase;
        }

        public async Task<bool> Handle(IncrementPrimeCounterCommand request, CancellationToken cancellationToken)
        {
            var currentPrimeNumberForCounter = _primeCounterDatabase.GetPrimeCounterValue(request.Name);

            if(!currentPrimeNumberForCounter.Item1)
            {
                return false;
            }

            var nextPrimeNumber = _primeNumberDatabase.GetNextPrimeNumber(currentPrimeNumberForCounter.Item2);
            var result = _primeCounterDatabase.IncrementPrimeCounter(request.Name, nextPrimeNumber);

            return result;
        }
    }
}
