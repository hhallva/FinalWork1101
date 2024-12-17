using ExamWork.Classes;

namespace Exam
{
    public class OrderProduct
    {
        public Order OrderID { get; set; }
        public Product ArticleNumber { get; set; }
        public int Amount { get; set; }
    }
}
