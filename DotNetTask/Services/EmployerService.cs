using Microsoft.Azure.Cosmos;
using DotNetTask.Models;

namespace DotNetTask.Services
{
    public class EmployerService : IEmployerService
    {
        private Container _container;
        private readonly IConfiguration configuration;

        public EmployerService(CosmosClient dbClient, string databaseName, string containerName)
        {
            //this.configuration = configuration;
            _container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(ProgramInformation item)
        {
            await _container.CreateItemAsync(item, new PartitionKey(item.id.ToString()));
        }

        public async Task DeleteItemAsync(string id)
        {
            await _container.DeleteItemAsync<ProgramInformation>(id, new PartitionKey(id));
        }

        public async Task<ProgramInformation> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<ProgramInformation> response = await _container.ReadItemAsync<ProgramInformation>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProgramInformation>> GetItemsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<ProgramInformation>(new QueryDefinition(queryString));
            List<ProgramInformation> results = new List<ProgramInformation>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateItemAsync(string id, ProgramInformation item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }
    }
}
