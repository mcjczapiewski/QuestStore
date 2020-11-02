using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuestStore.Models;

namespace QuestStore.ViewModels
{
    public class UserNameOnQuest
    {
        public List<string> UsersNameList { get; set; }
        public Quests Quests { get; set; }
    }
}
