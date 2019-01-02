using System;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;
using Xunit;

namespace XUnitAbpEventBus
{
    [DependsOn(typeof(AbpEventBusModule))]
    public class EventBusTestModule: AbpModule
    {
        
    }
}
