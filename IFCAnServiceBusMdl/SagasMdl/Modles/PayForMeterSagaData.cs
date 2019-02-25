using System;
using System.Collections.Generic;
using System.Text;
using NServiceBus;

namespace SagasMdl.Modles
{
    public class PayForMeterSagaData : ContainSagaData
    {
        /// <summary>
        /// 抄表计划单ID
        /// </summary>
        public Guid BillingId { get; set; }
        /// <summary>
        /// 此字段是【关键字】,抄表计划明细ID，
        /// <para>抄表计划明细对应抄表档案，再对应抄表标准，明细通过标准算出金额</para>
        /// </summary>
        public Guid BillingStandardId { get; set; }
        /// <summary>
        /// 付款是否成功
        /// <para>通过此判断付款是否已经付款成功，给saga模型判断全部完成</para>
        /// </summary>
        public bool PaymentIsCommited { get; set; }

    }
}
