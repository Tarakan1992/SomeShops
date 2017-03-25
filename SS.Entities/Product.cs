namespace SS.Entities
{
    public class Product : EntityBase<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
