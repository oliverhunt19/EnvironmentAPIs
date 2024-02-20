using HttpWebAPICore;

namespace EnvironmentAgencyAPI.Hydrology
{
    public abstract class HydrologyBaseRequest : BaseRequest
    {
        protected const string HydrologyRoot = "environment.data.gov.uk/hydrology/";

        protected abstract string RequestRootString { get; }
        protected override string BaseUrl => HydrologyRoot + RequestRootString;//+".json";
    }
}
