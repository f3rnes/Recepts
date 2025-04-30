using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReceptsAPI.Entity
{

    [Table("Stages")]
    public class Stage
    {
        [Key]
        public int Id { get; set; }
        public int ReceptId { get; set; }
        public int StageNumber { get; set; }
        public string? Photo { get; set; }
        public string Description { get; set; }


        [ForeignKey(nameof(ReceptId))]
        public Recept Recept { get; set; }

    }
}
