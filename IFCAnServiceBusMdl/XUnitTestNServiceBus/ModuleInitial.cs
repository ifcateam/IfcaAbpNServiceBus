using System;
using System.Diagnostics;
using System.Threading.Tasks;
using IFCAnServiceBusMdl.EndPoint;
using NServiceBus;
using ServiceBusTestDatas;
using Volo.Abp;
using Xunit;

namespace XUnitTestNServiceBus
{
    public class ModuleInitial : AbpIntegratedTest<TestNServiceBusModule>
    {
        private readonly IIFCAEndpoint _ifcaEndpoint;
        
        public ModuleInitial()
        {
            _ifcaEndpoint = GetRequiredService<IIFCAEndpoint>();
        }

        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }

        [Fact]
        public async Task TestInit()
        {
            var cmd = new PlaceOrderCmd() {OrderId = "001"};
            await _ifcaEndpoint.Send("OrderClient",cmd).ConfigureAwait(false);
            Debug.Print("ok");
        }
    }

   
}
