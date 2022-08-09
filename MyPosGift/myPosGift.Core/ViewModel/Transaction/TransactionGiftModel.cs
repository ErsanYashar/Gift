using myPosGift.Core.Services.Constants;
using System.ComponentModel.DataAnnotations;

namespace myPosGift.Core.ViewModel.Transaction
{
    public class TransactionGiftModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MinLength(ConstViewModel.MinDescLength, ErrorMessage = ConstViewModel.DescMinLengthErrorMessage)]
        [MaxLength(ConstViewModel.MaxDescLength, ErrorMessage = ConstViewModel.DescMaxLengthErrorMessage)]
        public string Description { get; set; }
    }
}
