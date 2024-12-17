using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork.Classes
{
    public class Product 
    {
        #region Свойства 
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public double Cost { get; set; }
        public int DiscountAmount { get; set; }
        public int QuantityInStock { get; set; }
        public string Status { get; set; }
        #endregion
    }
}
