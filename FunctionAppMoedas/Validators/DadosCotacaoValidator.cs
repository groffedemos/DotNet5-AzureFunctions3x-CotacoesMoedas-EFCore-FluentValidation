using FluentValidation;
using FunctionAppMoedas.Models;

namespace FunctionAppMoedas.Validators
{
    public class DadosCotacaoValidator : AbstractValidator<DadosCotacao>
    {
        public DadosCotacaoValidator()
        {
            RuleFor(c => c.Sigla).NotEmpty().WithMessage("Preencha o campo 'Sigla'")
                .Length(3, 3).WithMessage("O campo 'Sigla' deve possuir 3 caracteres");

            RuleFor(c => c.Valor).NotEmpty().WithMessage("Preencha o campo 'Valor'")
                .GreaterThan(0).WithMessage("O campo 'Valor' deve ser maior do 0");
        }                
    }
}