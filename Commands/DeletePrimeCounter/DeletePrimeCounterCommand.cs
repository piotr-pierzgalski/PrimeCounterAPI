using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commands.DeletePrimeCounter
{
    public class DeletePrimeCounterCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public DeletePrimeCounterCommand(string name)
        {
            Name = name;
        }
    }
}
