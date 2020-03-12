using Desafio.Business.Models;
using FluentValidation;

namespace Desafio.Business.Validations
{
    public class ObraValidation : AbstractValidator<Obra>
    {
        public ObraValidation()
        {
            RuleFor(o => o.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres");
            RuleFor(o => o.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 240).WithMessage("O campo {PropertyName} precisa ter {MinLength} e {MaxLength} caracteres");
            When(o => o.DataExposicao.ToString() == "", () => 
            {
                RuleFor(o => o.DataPublicacao)
                    .NotEmpty().WithMessage("Se a data de Exposição for vazia, a data de Publicação a precisa seer preenchida ");
            });
            When(o => o.DataPublicacao.ToString() == "", () =>
            {
                RuleFor(o => o.DataExposicao)
                    .NotEmpty().WithMessage("Se a data de Publicação for vazia, a data de Exposição a precisa seer preenchida ");
            });
        }
    }
}
