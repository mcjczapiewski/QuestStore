using System;
using System.Collections.Generic;

namespace QuestStore.Models
{
    public partial class UsersTech
    {
        public int UsersTechId { get; set; }
        public int? UserId { get; set; }
        public int? TechId { get; set; }

        public virtual Technologies Tech { get; set; }
        public virtual Users User { get; set; }
    }
}
