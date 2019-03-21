using System;
using Volo.Abp;
using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace IFCAnServiceBusMdl
{
    [DependsOn(typeof(AbpEventBusModule))]
    public class IFCAnServiceBusModule : AbpModule
    {
        
    }
}
