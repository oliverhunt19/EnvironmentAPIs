using GeoJSON.Net.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Flooding.Responces
{
    public class GeoFeatures
    {
        [JsonPropertyName("geometry")]
        public MultiPolygon Geometry { get; set; }
    }

    public class FloodAreaGeometry
    {
        [JsonPropertyName("features")]
        public IEnumerable<GeoFeatures> Features { get; set; }

    }
}
