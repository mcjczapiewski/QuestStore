using QuestStore.Models;
using System.Collections.Generic;

namespace QuestStore.ViewModels
{
    public class UserNameOnQuest
    {
        public List<string> UsersNameList { get; set; }
        public Quests Quests { get; set; }
    }
}
