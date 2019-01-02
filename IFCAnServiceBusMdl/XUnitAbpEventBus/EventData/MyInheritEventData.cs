using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitAbpEventBus.EventData
{
    public class MyInheritEventData : MySimpleEventData
    {
        public MyInheritEventData(int value)
            : base(value)
        {
        }
    }
}
