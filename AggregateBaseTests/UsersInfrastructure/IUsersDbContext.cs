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
    public interface IUsersDbContext : IEfCoreDbContext
    {
        DbSet<UserAggretgate> PaymentAggregates { get; set; }
    }
}
