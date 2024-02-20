using EnvironmentAgencyAPI.Flooding.Requests;

namespace EnvironmentAgencyAPITests.FunctionalTests
{
    [TestClass]
    public class TestStationResponce
    {
        [TestMethod]
        public async Task TestStationRespomce1()
        {
            StationRequest stationRequest = new StationRequest("45119");
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationAPI stationAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationAPI();
            var responce = await stationAPI.QueryAsync(stationRequest);
        }
    }
}
