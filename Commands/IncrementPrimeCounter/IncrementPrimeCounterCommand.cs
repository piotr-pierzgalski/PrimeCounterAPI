using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands.IncrementPrimeCounter
{
    public class IncrementPrimeCounterCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public IncrementPrimeCounterCommand(string name)
        {
            Name = name;
        }
    }
}
