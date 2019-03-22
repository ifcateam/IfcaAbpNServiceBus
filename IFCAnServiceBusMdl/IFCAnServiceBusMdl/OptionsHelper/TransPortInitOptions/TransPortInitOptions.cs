using NServiceBus;

namespace IFCAnServiceBusMdl.OptionsHelper.TransPortInitOptions
{
    public abstract class TransPortInitOptions : OptionsInitResponsibility
    {
        
        public TransPortInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        protected abstract void TransPortInit(IFCAnServiceBusOptions ifcAnServiceBusOptions);
      
        public override void Handle(
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            TransPortInit(ifcAnServiceBusOptions);           

        }
    }
}
