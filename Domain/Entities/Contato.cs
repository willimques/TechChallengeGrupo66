using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace Domain.Entities
{
    [Table("Contatos")]
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int DDD_ID { get; set; }
    }

    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(contato => contato.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(contato => contato.Email).NotEmpty().EmailAddress().WithMessage("O email é obrigatório e deve ser válido.");
            RuleFor(contato => contato.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\s\d{4,5}-\d{4}$").WithMessage("O telefone deve estar no formato XXXX-XXXX ou XXXXX-XXXX.");
        }
    }
}
