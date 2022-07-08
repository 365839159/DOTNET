using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Commands.Sample
{

    public class SampleCommand : IRequest<bool>
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
