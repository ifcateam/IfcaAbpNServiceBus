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
    public interface IPaymentDbContext : IEfCoreDbContext
    {
        DbSet<PaymentAggregate> PaymentAggregates { get; set; }
    }
}
