using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int NumberOfPpl { get; set; }

        public virtual ICollection<GroupsQuests> GroupsQuests { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
