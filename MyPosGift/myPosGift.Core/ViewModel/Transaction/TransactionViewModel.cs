namespace myPosGift.Core.ViewModel.Transaction
{
    public class TransactionViewModel
    {
        public decimal Amount { get; set; }
        public string RecipientName { get; set; }
        public string SenderName { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
