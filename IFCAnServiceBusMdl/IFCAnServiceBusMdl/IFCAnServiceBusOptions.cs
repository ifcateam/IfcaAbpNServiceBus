using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace IFCAnServiceBusMdl
{
    public enum ENUM_SERVICBUS_TESTORPRODUCT
    {
        Test =0,
        Product
    }

    public enum ENUM_LOCALorDISTRIBUTION
    {
        Local = 0,
        Distribution
    }

    public enum ENUM_TRANSPORT
    {
        Rabbitmq =0 ,
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
        /// Test：全部是Learning模式，本地调试，没有分布式，文件存储
        /// 
        /// </summary>
        public ENUM_SERVICBUS_TESTORPRODUCT TestorProduct { get; set; }
        /// <summary>
        /// 前提是生产环境，本地是outbox，分布式rabbitmq或者Azure ServiceBus选择
        /// </summary>
        public ENUM_LOCALorDISTRIBUTION LocaLorDistribution { get; set; }

        /// <summary>
        /// 分布式前提选择 消息中间件，连接字符串看配置文件
        /// </summary>
        public ENUM_TRANSPORT TransportType { get; set; }
        

    }
}
