
using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Enums;
using EnvironmentAgencyAPI.Flooding;
using HttpWebAPICore.Utilities;

namespace EnvironmentAgencyAPI.Flooding.Requests
{
    public class StationsRequest : EnvironmentAgencyIdentifiableThingsBaseRequest
    {
        protected override string RequestString => "stations";

        public string? Label { get; set; }
        public string? Town { get; set; }

        public string? RiverName { get; set; }

        public CoordinateAndRadius? CoordinateAndRadius { get; set; }

        public string? StationReference { get; set; }

        public string? Qualifier { get; set; }

        public MeasurementType? Parameter { get; set; }

        /// <summary>
        /// Return only those stations whose catchment name is exactly x. Not all stations have an associated catchment area.
        /// </summary>
        public string? Catchment { get; set; }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();
            parameters.AddNullable("label", Label);
            parameters.AddNullable("town", Town);
            parameters.AddNullable("riverName", RiverName);
            parameters.AddNullable("stationReference", StationReference);
            parameters.AddNullable("qualifier", Qualifier);
            parameters.AddNullable("parameter", Parameter);
            parameters.AddNullable("catchmentName", Catchment);
            if (CoordinateAndRadius != null)
            {
                var coordinateAndRadius = CoordinateAndRadius.Value;
                parameters.Add("lat", coordinateAndRadius.Centre.Lat.Degrees.ToString());
                parameters.Add("long", coordinateAndRadius.Centre.Lng.Degrees.ToString());
                parameters.Add("dist", coordinateAndRadius.Radius.Kilometers.ToString());
            }
            return parameters;
        }
    }
}
