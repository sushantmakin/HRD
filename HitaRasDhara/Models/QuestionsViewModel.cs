using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HitaRasDhara.Models
{
    public class QuestionsViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Listened At")]
        public string ListenedAt { get; set; }
    }
}