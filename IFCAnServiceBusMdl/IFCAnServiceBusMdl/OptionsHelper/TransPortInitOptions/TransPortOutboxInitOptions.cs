using NServiceBus;

namespace IFCAnServiceBusMdl.OptionsHelper.TransPortInitOptions
{
    public class TransPortOutboxInitOptions : TransPortInitOptions
    {
        public TransPortOutboxInitOptions(
            EndpointConfiguration endpointConfiguration) : base(
            endpointConfiguration)
        {
        }


        protected override void TransPortInit(
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            _endpointConfiguration.EnableOutbox();
        }
    }
}
