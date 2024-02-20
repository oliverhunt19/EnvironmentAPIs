using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Enums;
using HttpWebAPICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest
{
    public class StationReadingsRequest : ReadingsRequestBase
    {
        public string StationReference { get; }
        protected override string ReadingsRequestString => $"id/stations/{StationReference}";


        private DateTime? Since { get; set; }

        public StationReadingsRequest(string stationReference)
        {
            StationReference = stationReference;
        }

        public StationReadingsRequest(string stationReference, Date date) : base(date) { StationReference = stationReference; }

        public StationReadingsRequest(string stationReference, Date startDate, Date endDate) : base(startDate, endDate) { StationReference = stationReference; }

        public StationReadingsRequest(string stationReference, ReadingTime readingTime) : base(readingTime) { StationReference = stationReference; }
        public StationReadingsRequest(string stationReference, DateTime since) { StationReference = stationReference; Since = since; }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            var paramaters = base.GetQueryStringParameters();
            paramaters.AddNullable("since", Since?.ToString("O"));
            return paramaters;
        }

    }
}
