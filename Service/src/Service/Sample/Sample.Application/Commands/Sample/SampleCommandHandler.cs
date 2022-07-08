using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Commands.Sample
{
    public class SampleCommandHandler : IRequestHandler<SampleCommand, bool>
    {
        private readonly IValidator<SampleCommand> _validator;

        public SampleCommandHandler(IValidator<SampleCommand> validator)
        {
            _validator = validator;
        }

        public async Task<bool> Handle(SampleCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new ArgumentException(validationResult.ToString());
            return true;
        }
    }
}
