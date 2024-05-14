using Microsoft.Azure.Cosmos;

namespace CapitalPlacement.Data
{
    public class CosmosDbService : IDisposable
    {
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseName;

        public CosmosDbService(IConfiguration configuration)
        {
            var cosmosDbConfig = configuration.GetSection("CosmosDb");
            var endpointUri = cosmosDbConfig["EndpointUri"];
            var primaryKey = cosmosDbConfig["PrimaryKey"];
            _databaseName = cosmosDbConfig["DatabaseName"];

            _cosmosClient = new CosmosClient(endpointUri, primaryKey);
        }

        public Container GetContainer(string containerName)
        {
            var database = _cosmosClient.GetDatabase(_databaseName);
            var containerProperties = new ContainerProperties(containerName, partitionKeyPath: "/id");
            return database.CreateContainerIfNotExistsAsync(containerProperties, throughput: 400).Result;
        }

        public void Dispose()
        {
            _cosmosClient?.Dispose();
        }
    }
}
