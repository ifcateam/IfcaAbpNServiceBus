using System;
using NServiceBus;
using PayForMeterEventData.Meter;

namespace PayForMeterEventData.Payment
{
    /// <summary>
    /// 付款申请命令
    /// </summary>
    public class PaymentCmd : BaseEventDataForMeter, ICommand
    {

    }
}
