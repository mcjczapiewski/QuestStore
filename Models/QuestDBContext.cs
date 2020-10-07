using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuestStore.Models
{
    public class QuestDBContext : DbContext
    {
        public DbSet<user> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySql(@"server=91.192.164.15;uid=horizonp_cc-queststore;pwd=queststoreFORlajf;Database=horizonp_cc-queststore");
        }
    }
}
