using System.Collections.Generic;

namespace QuestStore.Models
{
    public partial class Technologies
    {
        public Technologies()
        {
            UsersTech = new HashSet<UsersTech>();
        }

        public int TechId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersTech> UsersTech { get; set; }
    }
}
