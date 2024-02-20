using EnvironmentAgencyAPI.Flooding.Responces;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.ReturnTypes
{
    public class FloodArea : ObjectID<FloodArea>
    {
        [JsonPropertyName("riverOrSea")]
        public string RiverOrSea { get; set; }

        /// <summary>
        /// This contains the URL and mechanism to get the object from the URL
        /// </summary>
        [JsonConverter(typeof(URLToObjectConverter<FloodAreaGeometry>))]
        [JsonPropertyName("polygon")]
        public URLObject<FloodAreaGeometry> Polygon { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("long")]
        public double Longitude { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("county")]
        public string County { get; set; }

        protected override FloodArea GetThis()
        {
            return this;
        }

        public override bool ObjectIsConstructed()
        {
            return false;
        }
    }
}
