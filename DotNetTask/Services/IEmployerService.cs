
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTask.Models;

public interface IEmployerService
    {
        Task AddItemAsync(ProgramInformation item);
        Task<ProgramInformation> GetItemAsync(string id);
        Task<IEnumerable<ProgramInformation>> GetItemsAsync(string queryString);
        Task UpdateItemAsync(string id, ProgramInformation item);
        Task DeleteItemAsync(string id);
    }




