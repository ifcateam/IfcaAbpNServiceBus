using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;

namespace NServiceBusTestBase
{
    public class TestData : ISingletonDependency
    {
        public static Guid BillingStandardId { get; } = new Guid("1fcf46b2-28c3-48d0-8bac-fa53268a2775");
        public static Guid BillingId { get; } = new Guid("1e28ca9f-df84-4f39-83fe-f5450ecbf5d4");
        public static decimal TotalAmo { get; } = 100;

        public static Guid PaymentAggregateId { get; } = new Guid("1a28ca9f-df84-df39-83fe-f5450ecbf5d4");
        public static Guid PaymentAggregateId2 { get; } = new Guid("1a38ca9f-df84-df39-83fe-f5450ecbf5d4");

    }
}
