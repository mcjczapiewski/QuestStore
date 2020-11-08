using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Models;

namespace QuestStore.ViewModels
{
    public class UserDetails
    {
        public Users Users { get; set; }
        public List<UsersTech> UsersTechs { get; set; }
        public List<Technologies> Technologies { get; set; }
        public List<Quests> Quests { get; set; }
    }
}
