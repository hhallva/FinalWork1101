using ExamWork.Classes;

namespace Exam
{
    public class Order
    {
        public int OrderID { get; set; }
        public User UserID { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }
        public PickupPoint PickupPointIndex { get; set; }
        public int PickupCode { get; set; }
    }
}
