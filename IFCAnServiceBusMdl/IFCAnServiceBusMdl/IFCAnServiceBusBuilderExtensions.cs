using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl.EndPoint;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace IFCAnServiceBusMdl
{
    public static class IFCAnServiceBusBuilderExtensions
    {
        /// <summary>
        /// 设置开启单例后台运行NServiceBus
        /// <para>为了照顾console应用程序，扩展Application初始化上下文</para>
        /// <para>请确保在应用程序的初始化模块进行使用，因为是后台运行的单例线程</para>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IIFCAEndpoint UseNServiceBus(
            this ApplicationInitializationContext context)
        {
            var endpoit = context.ServiceProvider.GetService<IIFCAEndpoint>();
            endpoit.InitInstance().ConfigureAwait(false);
            return endpoit;
        }
        
    }
}
