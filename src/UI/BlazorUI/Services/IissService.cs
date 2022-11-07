namespace BlazorUI.Services;

public interface IissService
{
    Task<IssMessageDto> GetPosition();
}