using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReceptsAPI.Entity
{
    [Table("Recepts")]
    public class Recept
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Photo { get; set; }

        public float Weight { get; set; }
        public string Ingredients { get; set; }
        public int AdminId { get; set; }

        [ForeignKey(nameof(AdminId))]
        public User Admin { get; set; }
    }

}
