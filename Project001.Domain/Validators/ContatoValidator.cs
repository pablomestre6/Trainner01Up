using FluentValidation;
using Project001.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Domain.Validators
{
    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator() 
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O seu id e obrigatorio");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome e obrigatorio")
                .Length(6, 150).WithMessage("Nome de contato precisa ter pelo menos caracteres");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email do contato é obriatorio")
                .EmailAddress().WithMessage("Endereço de email invalido");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Telefone e obrigatorio");
        }
    }
}
