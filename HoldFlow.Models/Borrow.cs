using HoldFlow.Models.Enums;

namespace HoldFlow.Models
{
    public class Borrow
    {
        public int BorrowId { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public BorrowStatus Status { get; set; }
        public ReturnCondition ReturnCondition { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int AdminId { get; set; }
        public User Admin { get; set; }
    }
}
