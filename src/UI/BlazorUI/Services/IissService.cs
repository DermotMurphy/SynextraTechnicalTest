using System.Threading.Tasks;

namespace BlazorUI.Services
{
    public interface IissService
    {
        Task<IssMessageDto> GetPosition();
    }
}