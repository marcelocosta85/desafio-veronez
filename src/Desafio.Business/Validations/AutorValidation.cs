using Desafio.Business.Models;
using Desafio.Business.Validations.Util;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Business.Validations
{
    public class AutorValidation : AbstractValidator<Autor>
    {
        public AutorValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres");
            RuleFor(a => a.DataNascimento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .LessThan(a => DateTime.Now).WithMessage("A data precisa estar no passado");
            RuleFor(a => a.PaisOrigem)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres");
            When(a => a.PaisOrigem == "Brasil", () => 
            {
                RuleFor(a => a.CPF.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo CPF precisa ter {CompaarisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(a => CpfValidacao.Validar(a.CPF)).Equal(true)
                    .WithMessage("O CPF é inválido.");
                
            });
            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("Email inválido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter no máximo {MaxLength} caracteres");
        }
    }
}
