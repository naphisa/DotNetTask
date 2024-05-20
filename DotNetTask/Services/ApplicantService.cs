using static System.Net.Mime.MediaTypeNames;
using DotNetTask.Models;
using Microsoft.Azure.Cosmos;
using DotNetTask.Models;

namespace DotNetTask.Services
{
    public class ApplicantService:IApplicantService
    {
        private Container _container;
        private readonly IConfiguration configuration;

        public ApplicantService(CosmosClient dbClient, string databaseName, string containerName)
        {
            //this.configuration = configuration;
            _container = dbClient.GetContainer(databaseName, containerName);
        }
        public async Task SubmitApplicationAsync(UserApplication application)
        {
            await _container.CreateItemAsync(application, new PartitionKey(application.id.ToString()));
        }
    }
}
