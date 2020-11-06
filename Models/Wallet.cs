using System;
using System.Collections.Generic;

namespace QuestStore.Models
{
    public partial class Wallet
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public decimal? Balance { get; set; }

        public virtual Users User { get; set; }
    }
}
