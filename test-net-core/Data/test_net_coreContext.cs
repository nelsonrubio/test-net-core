using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_net_core.Models;

namespace test_net_core.Data
{
    public class test_net_coreContext : DbContext
    {
        public test_net_coreContext (DbContextOptions<test_net_coreContext> options)
            : base(options)
        {
        }

        public DbSet<test_net_core.Models.aspirantes> aspirantes { get; set; }
    }
}
