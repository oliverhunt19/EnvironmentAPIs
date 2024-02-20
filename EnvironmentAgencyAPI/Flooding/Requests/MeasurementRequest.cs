using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Enums;
using EnvironmentAgencyAPI.Flooding;
using HttpWebAPICore;
using System.Runtime.Serialization;

namespace EnvironmentAgencyAPI.Flooding.Requests
{
    public class MeasurementRequest : EnvironmentAgencyIdentifiableThingsBaseRequest
    {
        protected override string RequestString => "measures";

        public string? StationReference { get; set; }
        public MeasurementType? Parameter { get; set; }
        public string? Qualifier { get; set; }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            var parameters = base.GetQueryStringParameters();
            parameters.AddNullable("stationReference", StationReference);
            parameters.AddNullable("parameter", Parameter);
            parameters.AddNullable("qualifier", Qualifier);
            return parameters;
        }
    }



}
