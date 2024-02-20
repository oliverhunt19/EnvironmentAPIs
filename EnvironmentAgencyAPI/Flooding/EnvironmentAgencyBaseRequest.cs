using HttpWebAPICore;

namespace EnvironmentAgencyAPI.Flooding
{
    public abstract class EnvironmentAgencyBaseRequest : BaseRequest
    {
        protected const string EnvironmentAgencyRoot = "environment.data.gov.uk/flood-monitoring/";

        protected abstract string RequestRootString { get; }

        protected sealed override string BaseUrl => EnvironmentAgencyRoot + RequestRootString;

        public int? Limit { get; set; }



        public bool ViewFull { get; set; }

        public override IList<KeyValuePair<string, string?>> GetQueryStringParameters()
        {
            List<KeyValuePair<string,string?>> parameters = new List<KeyValuePair<string,string?>>();
            parameters.AddBool("_view", "full", ViewFull);
            parameters.AddNullable("_limit", Limit?.ToString());
            return parameters;
        }

        public sealed override HttpRequestMessage GetHttpRequestMessage()
        {
            return base.GetHttpRequestMessage();
        }
    }

    public abstract class EnvironmentAgencyIdentifiableThingsBaseRequest : EnvironmentAgencyBaseRequest
    {

        protected abstract string RequestString { get; }

        protected sealed override string RequestRootString => $@"id/{RequestString}";
    }
}
