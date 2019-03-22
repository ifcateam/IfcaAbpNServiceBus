using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using IFCAnServiceBusMdl.OptionsHelper.OptionsProperty;

namespace IFCAnServiceBusMdl
{
    public enum ENUM_SERVICBUS_TESTORPRODUCT
    {
        Test =0,
        Product
    }

    public enum ENUM_StoragePersistence
    {
        Mysql = 0,
        Sqlserver
//        mongodb
    }

    public enum ENUM_TRANSPORT
    {
        LocalOutbox = 0,
        Rabbitmq,
        AzureServiceBus
    }

    public class IFCAnServiceBusOptions
    {
        public IFCAnServiceBusOptions()
        {
            CurrentServiceName = "DefaultClient";

        }

        public string CurrentServiceName { get; set; }
        public IContainer Container { get; set; }

        /// <summary>
        /// Test：全部是Learning模式，本地调试，没有分布式，是文件存储
        /// <para>生产环境：是可选择数据库类型，传输类型等</para>
        /// </summary>
        public ENUM_SERVICBUS_TESTORPRODUCT TestorProduct { get; set; }

        /// <summary>
        /// 前提是生产环境，都必须是数据持久化保证消息记录的追踪和重试等异常追踪机制
        /// </summary>
        public ENUM_StoragePersistence StoragePersistence { get; internal set; }

        /// <summary>
        /// 生产环境，传输对象默认和持久化没有关系，可选择rabbitmq，azure服务总线等消息中间件，需要连接字符串
        /// <para>LocalOutbox：是专为本地事务设计，本地持久化关系型数据库模拟实现的消息中间件</para>
        /// </summary>
        public ENUM_TRANSPORT TransportType { get; internal set; }

        internal OptionPropertyForStoragePersistence OptionPropertyForStoragePersistence
        {
            get;
            set;
        }

        internal OptionPropertyForTransPort OptionPropertyForTransPort { get; set; }


    }
}
