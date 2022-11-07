namespace BlazorUI.Services;

public class IssMessageDto
{
    public IssMessageDto()
    {
        IssPosition = new IssPositionDto();
    }
    public double Timestamp { get; set; }

    public IssPositionDto IssPosition { get; set; }

    public string? Message { get; set; }

    public DateTime LocalTime { get; set; }
}