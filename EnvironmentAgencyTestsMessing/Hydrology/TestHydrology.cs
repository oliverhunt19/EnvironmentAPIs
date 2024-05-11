using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Hydrology;
using EnvironmentAgencyAPI.Hydrology.Requests;
using RoutePlanning.Geometry;
using UnitsNet;

namespace EnvironmentAgencyTestsMessing.Hydrology
{
    [TestClass]
    public class TestHydrology
    {
        [TestMethod]
        public async Task Test1()
        {
            HydrologyAPI.StationAPI  stationAPI = HydrologyAPI.StationApi;
            var resp = await stationAPI.QueryAsync(new HydrologyStationRequest("c46d1245-e34a-4ea9-8c4c-410357e80e15"));
        }

        [TestMethod]
        public async Task Test2()
        {
            HydrologyAPI.StationsAPI stationsAPI = new HydrologyAPI.StationsAPI();
            var resp = await stationsAPI.QueryAsync(new HydrologyStationsRequest()
            {
                CoordinateAndRadius = new CoordinateAndRadius()
                {
                    Radius = Length.FromKilometers(10),
                    Centre = new LatLng(50.824309, -3.423293)
                }
            });
        }
    }
}
