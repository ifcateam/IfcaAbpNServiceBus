using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PaymentDomain.Modules;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace PaymentInfrastructure
{
    [ConnectionStringName("Default")]
    public class PaymentDbContext : AbpDbContext<PaymentDbContext>, IPaymentDbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<PaymentAggregate> PaymentAggregates { get; set; }
    }
}
