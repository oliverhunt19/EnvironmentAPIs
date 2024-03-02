using EnvironmentAgencyAPI.Flooding.Requests;
using EnvironmentAgencyAPI.Flooding.ReturnTypes;
using HttpWebAPICore.BaseClasses;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.Responces
{
    public class StationsResponce : BaseResponse<StationsRequest>
    {
        [JsonPropertyName("items")]
        public IEnumerable<MonitoringStation> Stations { get; set; }
    }



}
