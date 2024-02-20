using EnvironmentAgencyAPI.Flooding;

namespace EnvironmentAgencyAPI.Flooding.Requests
{
    public class StationRequest : EnvironmentAgencyIdentifiableThingsBaseRequest
    {
        public StationRequest(string stationReference)
        {
            if (string.IsNullOrEmpty(stationReference))
            {
                throw new ArgumentNullException(nameof(stationReference));
            }
            StationReference = stationReference;
        }

        protected override string RequestString => $@"stations/{StationReference}";

        public string StationReference { get; }

    }
}
