using FluentValidation;
using Sample.Application.Commands.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Validations
{
    public class SampleCommandValidation : AbstractValidator<SampleCommand>
    {
        public SampleCommandValidation()
        {
            RuleFor(command => command.Name).NotNull().NotEmpty().MinimumLength(5);
            RuleFor(command => command.Age).ExclusiveBetween(0, 120);
            RuleFor(command => command.Address).MaximumLength(1000);
            RuleFor(command => command.Email).EmailAddress();
        }
    }
}
