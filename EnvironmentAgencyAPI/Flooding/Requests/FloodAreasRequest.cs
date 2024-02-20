using HttpWebAPICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Flooding.Requests
{
    public class FloodAreasRequest : EnvironmentAgencyIdentifiableThingsBaseRequest
    {
        public CoordinateAndRadius? CoordinateAndRadius { get; set; }

        protected override string RequestString => "floodAreas";

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            IList<KeyValuePair<string, string?>> parameters = base.GetQueryStringParameters();
            if (CoordinateAndRadius != null)
            {
                var coordinateAndRadius = CoordinateAndRadius.Value;
                parameters.Add("lat", coordinateAndRadius.Centre.Lat.DecimalDegrees.ToString());
                parameters.Add("long", coordinateAndRadius.Centre.Lng.DecimalDegrees.ToString());
                parameters.Add("dist", coordinateAndRadius.Radius.Kilometers.ToString());
            }
            return parameters;
        }

        
    }
}
