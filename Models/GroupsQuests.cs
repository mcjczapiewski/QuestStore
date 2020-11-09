namespace QuestStore.Models
{
    public partial class GroupsQuests
    {
        public int GroupdQuestsId { get; set; }
        public int GroupId { get; set; }
        public int QuestId { get; set; }
        public string Status { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Quests Quest { get; set; }
    }
}
