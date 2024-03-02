using HttpWebAPICore;
using HttpWebAPICore.Utilities;

namespace EnvironmentAgencyAPI.Hydrology.Requests
{
    public class HydrologyStationsRequest : HydrologyBaseRequest
    {
        protected override string RequestRootString => "id/stations";

        public CoordinateAndRadius? CoordinateAndRadius { get; set; }

        public ObservedProperty? ObservedProperty { get; set; }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();
            if(CoordinateAndRadius.HasValue)
            {
                CoordinateAndRadius.Value.AddCentreAndRadius(parameters);
            }
            parameters.AddNullable("observedProperty", ObservedProperty?.ToEnumString('|'));
            return parameters;
        }
    }

    public enum ObservedProperty
    {
        waterFlow,
        waterLevel,
        rainfall,
        groundwaterLevel,
        dissolved_oxygen,
        fdom,
        bga,
        turbidity,
        chlorophyll,
        conductivity,
        temperature,
        ammonium,
        nitrate,
        ph
    }
}
