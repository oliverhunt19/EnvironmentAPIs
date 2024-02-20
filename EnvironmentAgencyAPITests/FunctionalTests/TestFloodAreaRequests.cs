using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Flooding.Requests;
using UnitsNet;

namespace EnvironmentAgencyAPITests.FunctionalTests
{
    [TestClass]
    public class TestFloodAreaRequests
    {
        [TestMethod]
        public async Task Test1()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.FloodAreasAPI floodAreasAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.FloodAreasAPI();
            var resp = await floodAreasAPI.QueryAsync(new FloodAreasRequest() {  CoordinateAndRadius = new CoordinateAndRadius() { Centre = new LatLng(50.823726, -3.423414),Radius = Length.FromMiles(5) } });

            var area = await resp.FloodAreas.First().GetObject();
        }
    }
}
