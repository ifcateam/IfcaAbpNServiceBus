using System;
using System.Collections.Generic;
using System.Text;

namespace PayForMeterEventData.Meter
{
    /// <summary>
    /// 付款的状态，demo也可以表示各聚合根单据状态
    /// </summary>
    public enum PAY_STATE
    {
        Init = 0, //初始化，创建
        Hanging,  //挂账
        Complete, //付款完成
        Cancel    //失败取消了


    }

    public abstract class BaseEventDataForMeter
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
        /// 明细计费金额
        /// </summary>
        public decimal TotalAmo { get; set; }


        /// <summary>
        /// 仪表编号
        /// </summary>r
        public string MeterIdentityNo { get; set; }

        /// <summary>
        /// 仪表类别 【户表、总表】
        /// </summary>
        public string MeterTypeElementCode { get; set; }

        /// <summary>
        /// 来源类型CF_PopupListElement.ElementCode 【合同、多经、设备】
        /// </summary>
        public string SourceTypeElementCode { get; set; }

        /// <summary>
        /// 来源内容
        /// 选择【合同】时，显示单元编号
        /// </summary>
        public string SourceContent { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 上次抄表读数
        /// </summary>
        public decimal LastReadingCount { get; set; }

        /// <summary>
        /// 上次抄表时间
        /// </summary>
        public DateTime LastReadingDate { get; set; }

        /// <summary>
        /// 当前抄表读数
        /// </summary>
        public decimal CurrentReadingCount { get; set; }

        /// <summary>
        /// 当前抄表时间
        /// </summary>
        public DateTime CurrentReadingDate { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        public decimal Dosage { get; set; }

        /// <summary>
        /// 实际用量
        /// </summary>
        public decimal ActualUsage { get; set; }

        /// <summary>
        /// 关联表用量
        /// </summary>
        public decimal AssociatedMeterUsage { get; set; }

        /// <summary>
        /// 抄表人
        /// </summary>
        public string MeterPerson { get; set; }
        
    }
}
