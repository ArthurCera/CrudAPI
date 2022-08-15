using FluentValidation;
using Model;

namespace Repositorio
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(Usuario => Usuario.ID).NotNull();
            RuleFor(Usuario => Usuario.ID).NotEqual(0);

            RuleFor(Usuario => Usuario.Nome).NotNull();
            RuleFor(Usuario => Usuario.Nome).NotEqual("");
            RuleFor(Usuario => Usuario.Nome).MaximumLength(100);

            RuleFor(Usuario => Usuario.Idade).NotNull();
            RuleFor(Usuario => Usuario.Idade).NotEqual(0);

            RuleFor(Usuario => Usuario.Sexo).NotNull();
            RuleFor(Usuario => Usuario.Sexo).NotEqual("");
            RuleFor(Usuario => Usuario.Sexo).MaximumLength(20);

            RuleFor(Usuario => Usuario.DocumentoTipo).NotNull();
            RuleFor(Usuario => Usuario.DocumentoTipo).NotEqual("");
            RuleFor(Usuario => Usuario.DocumentoTipo).MaximumLength(20);

            RuleFor(Usuario => Usuario.Rua).NotNull();
            RuleFor(Usuario => Usuario.Rua).NotEqual("");

            RuleFor(Usuario => Usuario.Numero).NotNull();
            RuleFor(Usuario => Usuario.Numero).NotEqual(0);

            RuleFor(Usuario => Usuario.Documento).NotNull();
            RuleFor(Usuario => Usuario.Documento).NotEqual("");
            RuleFor(Usuario => Usuario.Documento).MaximumLength(20);

            RuleFor(Usuario => Usuario.Complemento).NotNull();
            RuleFor(Usuario => Usuario.Complemento).NotEqual("");
            RuleFor(Usuario => Usuario.Complemento).MaximumLength(100);

            RuleFor(Usuario => Usuario.Bairro).NotNull();
            RuleFor(Usuario => Usuario.Bairro).NotEqual("");
            RuleFor(Usuario => Usuario.Bairro).MaximumLength(100);

            RuleFor(Usuario => Usuario.Cidade).NotNull();
            RuleFor(Usuario => Usuario.Cidade).NotEqual("");
            RuleFor(Usuario => Usuario.Cidade).MaximumLength(100);

            RuleFor(Usuario => Usuario.Estado).NotNull();
            RuleFor(Usuario => Usuario.Estado).NotEqual("");
            RuleFor(Usuario => Usuario.Estado).MaximumLength(100);

            RuleFor(Usuario => Usuario.Pais).NotNull();
            RuleFor(Usuario => Usuario.Pais).NotEqual("");
            RuleFor(Usuario => Usuario.Pais).MaximumLength(100);
        }
    }
}