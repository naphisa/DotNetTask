using DotNetTask.Models;
using DotNetTask.Models;

namespace DotNetTask.Services
{
    public interface IApplicantService
    {
        Task SubmitApplicationAsync(UserApplication application);
    }
}
