using MySql.Data.MySqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

namespace IFCAnServiceBusMdl.OptionsHelper.StoragePersInitOptions
{
    public class StoragePersMySqlInitOptions:StoragePersInitOptions
    {
        public StoragePersMySqlInitOptions(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration)
        {
        }

        protected override void SqlInit(PersistenceExtensions<SqlPersistence> sqlPersistence,
            IFCAnServiceBusOptions ifcAnServiceBusOptions)
        {
            sqlPersistence.SqlDialect<SqlDialect.MySql>();
            var connection =
                $"server=192.168.137.51;user=root;database=new_schema_Test;port=3306;password=123456;AllowUserVariables=True;AutoEnlist=false";
            sqlPersistence.ConnectionBuilder(
                connectionBuilder: () =>
                {
                    return new MySqlConnection(connection);
                });
        }
    }
}
