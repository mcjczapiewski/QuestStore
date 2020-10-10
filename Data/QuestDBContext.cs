using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;

namespace QuestStore.Data
{
    public class QuestDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public QuestDBContext (DbContextOptions<QuestDBContext> options)
            : base(options)
        {
        }
    }
}
