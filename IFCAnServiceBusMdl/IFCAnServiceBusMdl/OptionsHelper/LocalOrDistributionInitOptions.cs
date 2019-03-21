using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper
{
    public class LocalOrDistributionInitOptions: OptionsInitResponsibility
    {
        public LocalOrDistributionInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        public override void Handle(
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            var sqlPersistence =
                    _endpointConfiguration.UsePersistence<SqlPersistence>();
            sqlPersistence.SqlDialect<SqlDialect.MySql>();
            var connection = $"server=192.168.137.51;user=root;database=new_schema_Test;port=3306;password=123456;AllowUserVariables=True;AutoEnlist=false";
            sqlPersistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new MySqlConnection(connection);
                });
            var subscriptions = sqlPersistence.SubscriptionSettings();
            subscriptions.CacheFor(TimeSpan.FromMinutes(1));

            if (ifcAnServiceBusOptions.LocaLorDistribution ==
                ENUM_LOCALorDISTRIBUTION.Local)
            {
                //outbox 设置
                _endpointConfiguration.EnableOutbox();
            }           

            if (ifcAnServiceBusOptions.LocaLorDistribution ==
                ENUM_LOCALorDISTRIBUTION.Distribution)
            {
                SetSucceesorNext(
                    new TransPortAndPersInitOptions(_endpointConfiguration));
                _succeesorNext.Handle(ifcAnServiceBusOptions);
                
            }
        }
    }
}
