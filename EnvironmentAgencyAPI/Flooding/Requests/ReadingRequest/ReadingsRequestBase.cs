using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Enums;
using EnvironmentAgencyAPI.Flooding;
using HttpWebAPICore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest
{
    public abstract class ReadingsRequestBase : EnvironmentAgencyBaseRequest
    {
        private DateTime? ReadingDate;
        private DateTime? StartDate;
        private DateTime? EndDate;

        private ReadingTime? ReadingTime;

        protected abstract string ReadingsRequestString { get; }

        protected override string RequestRootString => $"{ReadingsRequestString}/readings";

        public bool Sorted { get; set; }

        public MeasurementType? Parameter { get; set; }

        public string? Qualifier { get; set; }

        protected ReadingsRequestBase(Date date)
        {
            ReadingDate = date.ToDateTime();
        }

        protected ReadingsRequestBase(Date startDate, Date endDate)
        {
            StartDate = startDate.ToDateTime();
            EndDate = endDate.ToDateTime();
        }

        protected ReadingsRequestBase(ReadingTime readingTime)
        {
            ReadingTime = readingTime;
        }

        protected ReadingsRequestBase()
        {
            Sorted = true;
        }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {

            var paramaters = base.GetQueryStringParameters();
            paramaters.AddNullable("date", ReadingDate?.ToString("yyyy-MM-dd"));
            paramaters.AddNullable("startdate", StartDate?.ToString("yyyy-MM-dd"));
            paramaters.AddNullable("enddate", EndDate?.ToString("yyyy-MM-dd"));
            paramaters.AddNullableKey(ReadingTime);
            paramaters.AddNullable("parameter", Parameter);
            paramaters.AddNullable("qualifier", Qualifier);
            paramaters.AddBool("_sorted", null, Sorted);
            return paramaters;
        }
    }
}
