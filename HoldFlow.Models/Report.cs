namespace HoldFlow.Models
{
    public class Report
    {
        public int ReportID { get; set; }
        public string ReportName { get; set; }
        public string ReportType { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportCreator { get; set; }
        public string Location { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CriticalLevel { get; set; }
        public int Quantity { get; set; }




    }
}
