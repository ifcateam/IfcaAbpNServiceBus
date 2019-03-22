using System;
using System.Collections.Generic;
using System.Text;
using IFCAnServiceBusMdl.OptionsHelper.OptionsProperty;

namespace IFCAnServiceBusMdl
{
    public static class IFCAnServiceBusOptionsExtensions
    {
        public static OptionPropertyForTransPort UseTransportSetting(
            this IFCAnServiceBusOptions options, ENUM_TRANSPORT transport)
        {
            options.TransportType = transport;
            options.OptionPropertyForTransPort = new OptionPropertyForTransPort(); 
            return options.OptionPropertyForTransPort;
        }

        public static OptionPropertyForStoragePersistence UsePersistenceSetting(
            this IFCAnServiceBusOptions options,
            ENUM_StoragePersistence storagePersistence)
        {
            options.StoragePersistence = storagePersistence;
            options.OptionPropertyForStoragePersistence = new OptionPropertyForStoragePersistence();
            return options.OptionPropertyForStoragePersistence;
        }
    }
}
