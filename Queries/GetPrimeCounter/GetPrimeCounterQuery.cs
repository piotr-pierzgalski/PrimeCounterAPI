using MediatR;

namespace Queries.GetPrimeCounter
{
    public class GetPrimeCounterQuery : IRequest<(bool, GetPrimeCounterQueryResult)>
    {
        public string Name { get; set; }

        public GetPrimeCounterQuery(string name)
        {
            Name = name;
        }
    }
}
