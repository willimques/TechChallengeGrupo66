using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("DDD")]
    public class DDD
    {
        [Key]
        public int Id { get; set; }
        public required string Estado  { get; set; }
        public int regiao { get; set; }
    }

    public class DDDValidador : AbstractValidator<DDD>
    {
        public DDDValidador()
        {
            RuleFor(ddd => ddd.Id).NotEmpty().WithMessage("O DDD é obrigatório.")
            .Must(id => id >= 10 && id <= 99).WithMessage("O DDD deve conter exatamente 2 dígitos."); ;

        }
    }

}
