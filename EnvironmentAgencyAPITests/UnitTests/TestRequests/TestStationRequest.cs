using EnvironmentAgencyAPI.Flooding.Requests;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPITests.UnitTests.TestRequests
{
    [TestClass]
    public class TestStationRequest
    {
        [TestMethod]
        public void TestStationRequest_GetUri()
        {
            StationRequest stationRequest = new StationRequest("E71333");

            stationRequest.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/id/stations/E71333");
        }
    }
}
