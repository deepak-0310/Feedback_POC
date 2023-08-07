using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedbackDemo.Core.Models
{
    public class FeedbackDetails:FeedbackDetailsUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Date_Time {get; set; }  
    }
    public class FeedbackDetailsUser
    {
        [Required]
        [MaxLength(50)]
        public string? UserName { get; set; }
        [MaxLength(1000)]
        public string? UserFeedback { get; set; }
    }
}
