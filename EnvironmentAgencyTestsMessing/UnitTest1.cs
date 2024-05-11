using EnvironmentAgencyAPI.Enums;
using EnvironmentAgencyAPI.Flooding.Requests;
using EnvironmentAgencyAPI.Flooding.ReturnTypes;
using FluentAssertions;
using RoutePlanning.Geometry;
using UnitsNet;

namespace EnvironmentAgencyAPITests.FunctionalTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            string riverName = "River Culm";

            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI stationAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI();

            StationsRequest request = new StationsRequest()
            {
                RiverName = riverName,
                ViewFull = true,
                Parameter = MeasurementType.Flow
            };

            var responce = await stationAPI.QueryAsync(request);

            responce.Stations.Select(x => x.RiverName).All(x => x == riverName).Should().BeTrue();
        }
        [TestMethod]
        public async Task TestMethod1_5()
        {
            string riverName = "River Culm";

            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI stationAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI();

            StationsRequest request = new StationsRequest()
            {
                //RiverName = riverName,
            };

            var responce = await stationAPI.QueryAsync(request);
            List<MonitoringStation> ans1 = responce.Stations.Where(x => x.StationMeasures is not null).ToList();
            //var param =  ans1.SelectMany(x => x.StationMeasures!).GroupBy(x => x.Parameter).Select(x => x.First()).ToList();

            var ans2 = ans1.Where(x => x.RLOIid == "7044").ToList();
        }

        [TestMethod]
        public async Task TestMethodStatus()
        {
            string riverName = "River Culm";

            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI stationAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI();

            StationsRequest request = new StationsRequest()
            {
                //RiverName = riverName,
            };

            var responce = await stationAPI.QueryAsync(request);
            List<MonitoringStation> ans1 = responce.Stations.Where(x => x.Status is not null).ToList();
            var param = ans1.Select(x => x.Status!).GroupBy(x => x).Select(x => x.First()).ToList();

        }

        [TestMethod]
        public async Task TestMethod2()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI stationAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI();

            StationsRequest request = new StationsRequest()
            {
                CoordinateAndRadius = new EnvironmentAgencyAPI.CoordinateAndRadius()
                {
                    Centre = new LatLng(50.824382, -3.423286),
                    Radius = Length.FromKilometers(100),
                },
                Qualifier = "Groundwater"
            };

            var responce = await stationAPI.QueryAsync(request);
        }
        [TestMethod]
        public async Task TestMethod3()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI stationAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.StationsAPI();

            StationsRequest request = new StationsRequest()
            {
                StationReference = "E71333",
            };

            var responce = await stationAPI.QueryAsync(request);
        }

        [TestMethod]
        public async Task TestMeasure()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.MeasureAPI measureAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.MeasureAPI();
            MeasurementRequest measurementRequest = new MeasurementRequest()
            {
                StationReference = "E71333",
            };
            var res = await measureAPI.QueryAsync(measurementRequest);

        }

        [TestMethod]
        public void TestMeasure2()
        {
            //https://stackoverflow.com/questions/60012370/how-do-i-ignore-exceptions-during-deserialization-of-bad-json
            Assert.Inconclusive("The current station cannot be deserialised properly so needs looking at ");
            // this doesn't deserilise properly needs looking into
            _ = "https://environment.data.gov.uk/flood-monitoring/id/stations/1090_w1TH";
        }
    }
}