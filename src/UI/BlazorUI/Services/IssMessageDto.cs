using System;

namespace BlazorUI.Services
{
    public class IssMessageDto
    {
        public double Timestamp { get; set; }

        public IssPositionDto IssPosition { get; set; }

        public string Message { get; set; }

        public DateTime LocalTime { get; set; }
    }
}