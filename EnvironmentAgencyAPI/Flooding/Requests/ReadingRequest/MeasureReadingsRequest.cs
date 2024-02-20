using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest
{
    public class MeasureReadingsRequest : ReadingsRequestBase
    {
        public string StationReference { get; }
        protected override string ReadingsRequestString => $"id/measures/{StationReference}";

        public MeasureReadingsRequest(string stationReference)
        {
            StationReference = stationReference;
        }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            throw new NotImplementedException();
            return base.GetQueryStringParameters();
        }

    }
}
