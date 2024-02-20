using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Enums;
using HttpWebAPICore;
using System.Runtime.Serialization;

namespace EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest
{

    public class ReadingsRequest : ReadingsRequestBase
    {
        protected override string ReadingsRequestString => "data";

        public string? StationReference { get; set; }

        public ReadingsRequest()
        {

        }

        public ReadingsRequest(Date date) : base(date) { }

        public ReadingsRequest(Date startDate, Date endDate) : base(startDate, endDate) { }

        public ReadingsRequest(ReadingTime readingTime) : base(readingTime) { }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            var parameter = base.GetQueryStringParameters();
            parameter.AddNullable("stationReference", StationReference);
            return parameter;
        }
    }




}
