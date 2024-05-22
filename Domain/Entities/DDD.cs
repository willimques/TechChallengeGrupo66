using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("DDD")]
    public class DDD
    {
        [Key]
        public int Id { get; set; }
        public required string estado  { get; set; }
        public int regiao { get; set; }
    }
   
}
