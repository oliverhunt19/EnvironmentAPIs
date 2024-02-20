using EnvironmentAgencyAPI.Hydrology.Requests;
using EnvironmentAgencyAPI.Hydrology.Responces;
using HttpWebAPICore;

namespace EnvironmentAgencyAPI.Hydrology
{
    /// <summary>
    /// https://environment.data.gov.uk/hydrology/doc/reference#identifiers
    /// </summary>
    public class HydrologyAPI 
    {
        public static StationAPI StationApi { get; } = new StationAPI();
        public class StationAPI : APIBase<HydrologyStationRequest, HydrologyStationResponce>
        {

        }

        public class StationsAPI : APIBase<HydrologyStationsRequest,HydrologyStationsResponce>
        {

        }
    }
}
