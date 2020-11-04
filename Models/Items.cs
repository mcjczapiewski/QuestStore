using System;
using System.Collections.Generic;

namespace QuestStore.Models
{
    public partial class Items
    {
        public Items()
        {
            UserInventory = new HashSet<UserInventory>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Extra { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<UserInventory> UserInventory { get; set; }
    }
}
