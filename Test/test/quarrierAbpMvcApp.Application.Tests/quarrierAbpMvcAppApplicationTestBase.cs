using Volo.Abp;

namespace quarrierAbpMvcApp
{
    public abstract class quarrierAbpMvcAppApplicationTestBase : AbpIntegratedTest<quarrierAbpMvcAppApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}
