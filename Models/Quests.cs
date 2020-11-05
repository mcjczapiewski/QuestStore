using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestStore.Models
{
    public partial class Quests
    {
        public Quests()
        {
            GroupsQuests = new HashSet<GroupsQuests>();
            UsersQuests = new HashSet<UsersQuests>();
        }

        public int QuestId { get; set; }
        public string Title { get; set; }
        public int Reward { get; set; }
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool? Extra { get; set; }

        public virtual ICollection<GroupsQuests> GroupsQuests { get; set; }
        public virtual ICollection<UsersQuests> UsersQuests { get; set; }
    }
}
