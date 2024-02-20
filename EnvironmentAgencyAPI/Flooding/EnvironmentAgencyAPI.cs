using EnvironmentAgencyAPI.Flooding.Requests;
using EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest;
using EnvironmentAgencyAPI.Flooding.Responces;
using HttpWebAPICore;

namespace EnvironmentAgencyAPI.Flooding
{
    /// <summary>
    /// https://environment.data.gov.uk/flood-monitoring/doc/reference
    /// </summary>
    public class EnvironmentAgencyAPI
    {
        public static readonly StationAPI StationAPi = new();

        public static readonly StationsAPI StationsAPi = new();

        public class StationsAPI : APIBase<StationsRequest, StationsResponce>
        {

        }

        public class MeasureAPI : APIBase<MeasurementRequest, MeasuresResponce>
        {

        }

        public class StationAPI : APIBase<StationRequest, StationResponce>
        {

        }

        public class ReadingsAPI : APIBase<ReadingsRequestBase, ReadingsResponce>
        {

        }

        public class FloodAreasAPI : APIBase<FloodAreasRequest, FloodAreasResponce>
        {

        }
    }
}
