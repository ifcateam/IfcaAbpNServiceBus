using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBus;
using Volo.Abp.DependencyInjection;

namespace IFCAnServiceBusMdl.OptionsHelper
{
    /// <summary>
    /// option职责链初始化配置信息
    /// <para>基础->测试/生产->持久化->消息中间件配置</para>
    /// </summary>
    public abstract class OptionsInitResponsibility 
    {
        protected OptionsInitResponsibility _succeesorNext;        
        protected EndpointConfiguration _endpointConfiguration;
        


        protected OptionsInitResponsibility(EndpointConfiguration endpointConfiguration)
        {
            _endpointConfiguration = endpointConfiguration;
        }

        public abstract void Handle(IFCAnServiceBusOptions ifcAnServiceBusOptions);
    
        public void SetSucceesorNext(OptionsInitResponsibility optionsResponsibility)
        {
            _succeesorNext = optionsResponsibility;
        }
    }
}

