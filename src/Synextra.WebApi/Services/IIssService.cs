using System.Threading.Tasks;
using Synextra.Domain;

namespace Synextra.WebApi.Services
{
    public interface IIssService
    {
        Task<IssMessage> GetMessageAsync();
    }
}