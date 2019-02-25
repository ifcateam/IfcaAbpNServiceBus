using System;
using System.Threading;
using NServiceBus;

namespace PayForMeterEventData.Meter
{
    /// <summary>
    /// 计费成功的事件数据
    /// </summary>
    public class ChargeEventData : BaseEventDataForMeter, IEvent
    {
        
    }
}
