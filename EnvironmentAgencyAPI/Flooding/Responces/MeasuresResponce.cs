using EnvironmentAgencyAPI.Flooding.Requests;
using EnvironmentAgencyAPI.Flooding.ReturnTypes;
using HttpWebAPICore;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.Responces
{
    public class MeasuresResponce : BaseResponse<MeasurementRequest>
    {
        [JsonPropertyName("items")]
        public IEnumerable<MeasuresData> Stations { get; set; }
    }

    public class MeasuresData
    {
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("latestReading")]
        public Reading Reading { get; set; }

        public string notation { get; set; }

        public string parameter { get; set; }

        public string parameterName { get; set; }

        public double period { get; set; }

        public string qualifier { get; set; }

        public string station { get; set; }

        public string stationReference { get; set; }

        public string unit { get; set; }

        public string unitName { get; set; }

        public string valueType { get; set; }
    }
}
