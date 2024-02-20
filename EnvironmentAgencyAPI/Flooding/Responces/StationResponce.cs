using EnvironmentAgencyAPI.Flooding.Requests;
using EnvironmentAgencyAPI.Flooding.ReturnTypes;
using HttpWebAPICore;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.Responces
{
    public class StationResponce : BaseResponse<StationRequest>
    {
        [JsonPropertyName("items")]
        public MonitoringStation Station { get; set; }
    }
}
