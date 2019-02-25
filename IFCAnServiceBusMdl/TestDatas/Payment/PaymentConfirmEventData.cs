using System;
using NServiceBus;

namespace PayForMeterEventData.Payment
{
    public abstract class BaseForPaymentEventData : IEvent
    {
        /// <summary>
        /// 此字段是【关键字】，抄表计划明细ID，
        /// <para>抄表计划明细对应抄表档案，再对应抄表标准，明细通过标准算出金额</para>
        /// </summary>
        public Guid BillingStandardId { get; set; }
        /// <summary>
        /// 抄表计划单ID
        /// </summary>
        public Guid BillingId { get; set; }
        /// <summary>
        /// 付款单编号
        /// </summary>
        public Guid PaymentId { get; set; }
    }

    /// <summary>
    /// 付款成功事件数据
    /// </summary>
    public class PaymentConfirmEventData : BaseForPaymentEventData
    {
        

    }
}
