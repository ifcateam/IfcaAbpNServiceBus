using System;
using System.Collections.Generic;
using System.Text;
using IfcaAbpIocHelper;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBusTestBase;
using UsersDomain;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AggregateEventTests
{
    public class
        AggregateEventTestClient : NServiceBusTestBase<AggregateEventTestModule>
    {
        private readonly IIFCAEndpoint _ifcaEndpoint;
        private readonly IRepository<UserAggretgate, Guid> _userAggretgates;

        public AggregateEventTestClient()
        {
            IfcaIocContainerProvider.Build(this.RootServiceProvider);
            _ifcaEndpoint = GetRequiredService<IIFCAEndpoint>();
            _userAggretgates =
                GetRequiredService<IRepository<UserAggretgate, Guid>>();

        }

        [Fact]
        public void AddEvents_Test()
        {
            var user = new UserAggretgate();
            var id = user.Id;
            user.TodoAddTestEvent();
            _userAggretgates.Insert(user, true);                        

        }
    }
}
