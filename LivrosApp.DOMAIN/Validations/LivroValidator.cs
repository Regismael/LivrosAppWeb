using FluentValidation;
using LivrosApp.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrosApp.DOMAIN.Validations
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty().WithMessage("O Id apresentado não existe. Por favor, verifique.");

            RuleFor(l => l.Titulo)
                .NotEmpty().WithMessage("O preenchimento do título do livro é obrigatório.")
                .Length(5, 100).WithMessage("O título deve conter de 5 a 100 caracteres, obrigatoriamente.");

            RuleFor(l => l.Autor)
                .NotEmpty().WithMessage("O preenchimento do nome do autor é obrigatório.")
                .Length(5, 100).WithMessage("O nome do autor deve conter de 5 a 100 caracteres, obrigatoriamente.");

            RuleFor(l => l.Genero)
                .NotEmpty().WithMessage("O preenchimento do gênero do livro é obrigatório.")
                .IsInEnum().WithMessage("O gênero do livro não é válido. Por favor, verifique.");

            RuleFor(l => l.AnoDePublicacao)
                .NotEmpty().WithMessage("O preenchimento do ano de publicação é obrigatório.")
                .InclusiveBetween(1800, DateTime.Now.Year).WithMessage("O ano de publicação deve estar entre 1800 e o ano atual.");

            RuleFor(l => l.Disponibilidade)
                .NotNull().WithMessage("A informação de disponibilidade do livro é obrigatória.");

            RuleFor(l => l.Ativo)
                .NotNull().WithMessage("A informação de Ativo ou Inativo do livro é obrigatória.");
        }
    }

}
