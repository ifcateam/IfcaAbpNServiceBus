using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace NServiceBusTestBase
{
    /// <summary>
    /// 测试基础类入口
    /// </summary>
    public class
        NServiceBusTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule>
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(
            AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
