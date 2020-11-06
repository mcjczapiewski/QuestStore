using System;
using System.Collections.Generic;

namespace QuestStore.Models
{
    public partial class UserInventory
    {
        public int InventoryId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public bool ItemUsed { get; set; }

        public virtual Items Item { get; set; }
        public virtual Users User { get; set; }
    }
}
