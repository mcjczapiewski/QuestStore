using System;
using System.Collections.Generic;

namespace QuestStore.Models
{
    public partial class Groups
    {
        public Groups()
        {
            GroupsQuests = new HashSet<GroupsQuests>();
            Users = new HashSet<Users>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public int NumberOfPpl { get; set; }

        public virtual ICollection<GroupsQuests> GroupsQuests { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
