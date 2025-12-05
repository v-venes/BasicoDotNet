using System;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class UpdateAvisoRequestValidator : AbstractValidator<UpdateAvisoRequest>
    {
        public UpdateAvisoRequestValidator()
        {
            RuleFor(request => request.Mensagem)
                .NotEmpty()
                .NotNull()
                .WithMessage("A Mensagem é obrigarória!");
        }
    }
}

