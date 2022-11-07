using Newtonsoft.Json;

namespace Synextra.Domain;

//
// http://open-notify.org/Open-Notify-API/ISS-Location-Now/
//
public class IssMessage
{
    [JsonProperty("timestamp")]
    public double Timestamp { get; set; }              // UNIX_TIME_STAMP
    [JsonProperty("iss_position")]
    public IssPosition? IssPosition { get; set; }
    [JsonProperty("message")]
    public string? Message { get; set; }

    public DateTime LocalTime => UnixTimeStampToLocalTime(Timestamp);

    public static DateTime UnixTimeStampToLocalTime(double unixTimeStamp)
    {
        //The unix timestamp is traditionally a 32 bit integer, and has a range of
        // '1970-01-01 00:00:01' UTC to '2038-01-19 03:14:07' UTC.
        var dateTime = DateTime.UnixEpoch.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTime;
    }
}