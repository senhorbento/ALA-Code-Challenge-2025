namespace API.Models
{
    public class Purchase
    {
        public long id { get; set; } = -1;
        public long userID { get; set; } = -1;
        public DateTime orderDate { get; set; }
        public decimal total { get; set; } = -1;
    }
    public class PurchaseInsert
    {
        public long userID { get; set; } = -1;
        public DateTime orderDate { get; set; }
        public decimal total { get; set; } = -1;
    }
    public class PurchaseUpdate
    {
        public long id { get; set; } = -1;
        public long userID { get; set; } = -1;
        public DateTime orderDate { get; set; }
        public decimal total { get; set; } = -1;
    }
}