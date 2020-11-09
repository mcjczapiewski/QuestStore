namespace QuestStore.Models
{
    public partial class UsersQuests
    {
        public int UsersQuestId { get; set; }
        public int UserId { get; set; }
        public int QuestId { get; set; }
        public string Status { get; set; }

        public virtual Quests Quest { get; set; }
        public virtual Users User { get; set; }
    }
}
