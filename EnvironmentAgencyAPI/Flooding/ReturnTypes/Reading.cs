using HttpWebAPICore;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.ReturnTypes
{
    public class Reading
    {
        public DateTime dateTime { get; set; }

        [JsonConverter(typeof(StringObjectConverter<StationMeasures>))]
        public StationMeasures measure { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<double>))]
        public double value { get; set; }
    }
}
