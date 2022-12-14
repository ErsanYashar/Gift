using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static myPosGift.Infrastructure.Data.DataConstants;

namespace myPosGift.Infrastructure.Data.DateModels
{
    public class Transaction
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string RecipientName { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string SenderName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }


    }
}
