using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReceptsAPI.Entity
{

    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int ReceptId { get; set; }
        public int UserId { get; set; }
        public bool Mood { get; set; }
        public string Description { get; set; }


        [ForeignKey(nameof(ReceptId))]
        public Recept Recept { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
