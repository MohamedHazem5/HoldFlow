namespace HoldFlow.Models
{
    public class Inventory : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Package> Packages { get; set; }
    }
}
