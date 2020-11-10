using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands.CreatePrimeCounter
{
    public class CreatePrimeCounterCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public CreatePrimeCounterCommand(string name)
        {
            Name = name;
        }
    }
}
