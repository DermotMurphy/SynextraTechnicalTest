using Newtonsoft.Json;
using Xunit;

namespace Synextra.Domain.Unit.Tests;

public class IssMessageTests
{
    [Fact]
    public void CanDeserialise_IssMessage()
    {
        const string json =
            @"{""timestamp"": 0, ""iss_position"": {""latitude"": ""53.394576"", ""longitude"": ""-3.179156""}, ""message"": ""success""}";

#pragma warning disable CS8600
        IssMessage issMessage = JsonConvert.DeserializeObject<IssMessage>(json);
#pragma warning restore CS8600
        Assert.NotNull(issMessage);
        Assert.Equal("success", issMessage.Message);
        Assert.Equal(0, issMessage.Timestamp);
        Assert.Equal(53.394576, issMessage.IssPosition!.Latitude);
        Assert.Equal(-3.179156, issMessage.IssPosition.Longitude);
        Assert.Equal(DateTime.UnixEpoch, issMessage.LocalTime);
    }


    [Theory]
    [InlineData(0, "1970-01-01T00:00:00.0000000+00:00")]
    [InlineData(870782122, "1997-08-05T12:55:22.0000000+01:00")]
    [InlineData(135141153, "1974-04-14T04:12:33.0000000+01:00")]
    public void CanConvertUtcTimeToLocalTime(double unixTimeStamp, string expectedDateTime)
    {
        var expected = DateTime.Parse(expectedDateTime);
        Assert.Equal(expected, IssMessage.UnixTimeStampToLocalTime(unixTimeStamp));
    }

}