using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitAbpEventBus.EventData
{
    public class MySimpleEventData
    {
        public int Value { get; set; }

        public MySimpleEventData(int value)
        {
            Value = value;
        }
    }
}
