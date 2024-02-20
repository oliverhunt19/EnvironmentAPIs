using EnvironmentAgencyAPI;
using EnvironmentAgencyAPI.Flooding.Requests;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace EnvironmentAgencyAPITests.UnitTests.TestRequests
{
    [TestClass]
    public class TestStationsRequest
    {
        [TestMethod]
        public void GetStationsUriTest_noParamaters()
        {
            StationsRequest stationsRequest = new StationsRequest();
            stationsRequest.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/id/stations");
        }

        [TestMethod]
        public void GetStationsUriTest_CentreRadius()
        {
            StationsRequest stationsRequest = new StationsRequest()
            {
                CoordinateAndRadius = new CoordinateAndRadius()
                {
                    Centre = new LatLng(50,3),
                    Radius = Length.FromKilometers(5)
                }
            };
            stationsRequest.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/id/stations?lat=50&long=3&dist=5");
        }

        [TestMethod]
        public void GetStationsUriTest_Rivername()
        {
            StationsRequest stationsRequest = new StationsRequest()
            {
                RiverName = "River Culm"
            };
            stationsRequest.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/id/stations?riverName=River%20Culm");
        }
    }
}
