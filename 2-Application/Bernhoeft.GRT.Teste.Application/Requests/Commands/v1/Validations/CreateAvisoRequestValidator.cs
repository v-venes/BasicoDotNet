using System;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class CreateAvisoRequestValidator : AbstractValidator<CreateAvisoRequest>
    {
        public CreateAvisoRequestValidator()
        {
            RuleFor(request => request.Titulo)
                .NotEmpty()
                .NotNull()
                .WithMessage("O Título é obrigatório!");
            RuleFor(request => request.Mensagem)
                .NotEmpty()
                .NotNull()
                .WithMessage("A Mensagem é obrigarória!");
        }
    }
}

