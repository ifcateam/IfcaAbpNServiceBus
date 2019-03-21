using System;
using System.Collections.Generic;
using System.Text;
using IFCA.Framework.Domain;

namespace UsersDomain
{
    public class UserAggretgate : AggregateRootBase<Guid>
    {
        public UserAggretgate()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Tel { get; set; }

        public void TodoAddTestEvent()
        {
            AddLocalEvent(new AddUserEventData() {DataValue = "opq"});
        }

    }
}
