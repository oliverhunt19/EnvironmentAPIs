using EnvironmentAgencyAPI.Enums;
using EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPITests.UnitTests.TestRequests
{
    [TestClass]
    public class ReadingRequestsTest
    {
        [TestMethod]
        public void TestReadingBaseRequest_NoParamters()
        {
            ReadingsRequest stationReadings = new ReadingsRequest();
            stationReadings.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/data/readings");
        }

        [TestMethod]
        public void TestReadingBaseRequest_Today()
        {
            ReadingsRequest stationReadings = new ReadingsRequest(ReadingTime.Today);
            stationReadings.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/data/readings?today");
        }

        [TestMethod]
        public void TestReadingBaseRequest_Latest()
        {
            ReadingsRequest stationReadings = new ReadingsRequest(ReadingTime.Latest);
            stationReadings.GetUri().AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/data/readings?latest");
        }
    }
}
