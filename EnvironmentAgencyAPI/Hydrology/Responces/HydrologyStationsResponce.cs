using EnvironmentAgencyAPI.Hydrology.Requests;
using HttpWebAPICore.BaseClasses;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Hydrology.Responces
{
    public class HydrologyStationsResponce : BaseResponse<HydrologyStationsRequest>
    {
        [JsonPropertyName("items")]
        public IEnumerable<HydrologyStation> Stations { get; set; }
    }

    public class HydrologyStation
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("long")]
        public double Longitude { get; set; }

        [JsonPropertyName("stationGuid")]
        public Guid StationGUID { get; set; }

        [JsonPropertyName("stationReference")]
        public string StationReference { get; set; }

        [JsonPropertyName("wiskiID")]
        public string WISKI_ID { get; set; }

        public string? RLOIid { get; set; }

        [JsonPropertyName("type")]
        public IEnumerable<dynamic> Types { get; set; }
    }
}
