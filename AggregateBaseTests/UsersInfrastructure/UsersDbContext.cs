using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UsersDomain;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace UsersInfrastructure
{
    
    [ConnectionStringName("Default")]
    public class UsersDbContext : AbpDbContext<UsersDbContext>, IUsersDbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        public DbSet<UserAggretgate> PaymentAggregates { get; set; }
    }
}
