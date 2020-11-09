using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestStore.Models
{
    public partial class GroupsInventory
    {
        [Key]
        public int InventoryId { get; set; }
        public int GroupId { get; set; }
        public int ItemId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool ItemUsed { get; set; }

        public virtual Items Item { get; set; }
        public virtual Groups Group { get; set; }
    }
}
