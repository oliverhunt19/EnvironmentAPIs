using EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest;
using EnvironmentAgencyAPI.Flooding.ReturnTypes;
using HttpWebAPICore;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.Responces
{
    public class ReadingsResponce : BaseResponse<ReadingsRequestBase>
    {
        [JsonPropertyName("items")]
        public IEnumerable<Reading> Readings { get; set; }
    }
}
