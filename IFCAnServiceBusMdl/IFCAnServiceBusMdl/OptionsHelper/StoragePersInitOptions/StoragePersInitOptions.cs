using System;
using IFCAnServiceBusMdl.OptionsHelper.TransPortInitOptions;
using MySql.Data.MySqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper.StoragePersInitOptions
{
    public abstract class StoragePersInitOptions: OptionsInitResponsibility
    {
        public StoragePersInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        protected abstract void SqlInit(
            PersistenceExtensions<SqlPersistence> sqlPersistence,
            IFCAnServiceBusOptions ifcAnServiceBusOptions);

        public override void Handle(
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            var sqlPersistence =
                _endpointConfiguration.UsePersistence<SqlPersistence>();
            sqlPersistence.DisableInstaller();
            
            SqlInit(sqlPersistence, ifcAnServiceBusOptions);

            var subscriptions = sqlPersistence.SubscriptionSettings();
            subscriptions.CacheFor(TimeSpan.FromMinutes(1));

            FactoryCreateNextSucceesorTransport(ifcAnServiceBusOptions
                .TransportType);
            _succeesorNext.Handle(ifcAnServiceBusOptions);
        }

        private void FactoryCreateNextSucceesorTransport(
           ENUM_TRANSPORT enumTransport)
        {
            switch (enumTransport)
            {
                case ENUM_TRANSPORT.Rabbitmq:
                    SetSucceesorNext(
                        new TransPortRabbitmqInitOptions(_endpointConfiguration));
                    break;
                case ENUM_TRANSPORT.LocalOutbox:
                    SetSucceesorNext(
                        new TransPortOutboxInitOptions(_endpointConfiguration));
                    break;
                case ENUM_TRANSPORT.AzureServiceBus:
                    break;
            }


        }
    }
}
