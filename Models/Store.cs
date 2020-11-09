namespace QuestStore.Models
{
    public partial class Store
    {
        public int StoreItemId { get; set; }
        public int? ItemId { get; set; }
        public int? NumberAvailable { get; set; }
        public decimal? Price { get; set; }

        public virtual Items Item { get; set; }
    }
}
