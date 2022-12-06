using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CardWebApi1.Data
{
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }

            public DbSet<Member> Members { get; set; }
            public DbSet<Card> Cards { get; set; }
        }
}
