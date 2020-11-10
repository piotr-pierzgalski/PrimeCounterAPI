using MediatR;
using Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.GetPrimeCounter
{
    public class GetPrimeCounterQueryHandler : IRequestHandler<GetPrimeCounterQuery, (bool, GetPrimeCounterQueryResult)>
    {
        private IPrimeCounterDatabase _primeCounterDatabase;

        public GetPrimeCounterQueryHandler(
            IPrimeCounterDatabase primeCounterDatabase
            )
        {
            _primeCounterDatabase = primeCounterDatabase;
        }

        public async Task<(bool, GetPrimeCounterQueryResult)> Handle(GetPrimeCounterQuery request, CancellationToken cancellationToken)
        {
            var currentPrimeNumberForCounter = _primeCounterDatabase.GetPrimeCounterValue(request.Name);

            return 
                (currentPrimeNumberForCounter.Item1,
                new GetPrimeCounterQueryResult() { Value = currentPrimeNumberForCounter.Item2 });
        }
    }
}
