using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestStore.Models
{
    public partial class Users
    {
        public Users()
        {
            UserInventory = new HashSet<UserInventory>();
            UsersQuests = new HashSet<UsersQuests>();
            UsersTech = new HashSet<UsersTech>();
        }

        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Gender { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Age { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Mentor { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? GroupId { get; set; }
        public string CredentialsId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<UserInventory> UserInventory { get; set; }
        public virtual ICollection<UsersQuests> UsersQuests { get; set; }
        public virtual ICollection<UsersTech> UsersTech { get; set; }
    }
}
