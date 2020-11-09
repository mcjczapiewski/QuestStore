using QuestStore.Models;
using System.Collections.Generic;

namespace QuestStore.ViewModels
{
    public class UserDetails
    {
        public Users Users { get; set; }
        public List<UsersTech> UsersTechs { get; set; }
        public List<Technologies> Technologies { get; set; }
        public List<Quests> Quests { get; set; }
        public List<UsersQuests> UsersQuests { get; set; }
    }
}
