using EnvironmentAgencyAPI.Enums;
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
    public class MeasurementRequestTests
    {
        [TestMethod]
        public void GetQueryStringParameters_ReturnsCorrectParameters()
        {
            // Arrange
            var measurementRequest = new MeasurementRequest
            {
                StationReference = "station123",
                Parameter = MeasurementType.Temperature,
                Qualifier = "high"
            };

            // Act
            var queryStringParameters = measurementRequest.GetQueryStringParameters();

            // Assert
            Assert.IsNotNull(queryStringParameters);
            Assert.AreEqual(3, queryStringParameters.Count); 

            Assert.IsTrue(queryStringParameters.Contains(new KeyValuePair<string, string?>("stationReference", "station123")));
            Assert.IsTrue(queryStringParameters.Contains(new KeyValuePair<string, string?>("parameter", "temperature")));
            Assert.IsTrue(queryStringParameters.Contains(new KeyValuePair<string, string?>("qualifier", "high")));
        }

        [TestMethod]
        public void GetQueryStringParameters_ReturnsCorrectUri()
        {
            var measurementRequest = new MeasurementRequest
            {
                StationReference = "station123",
                Parameter = MeasurementType.Temperature,
                Qualifier = "high"
            };

            Uri uri = measurementRequest.GetUri();
            uri.AbsoluteUri.Should().Be("https://environment.data.gov.uk/flood-monitoring/id/measures?stationReference=station123&parameter=temperature&qualifier=high");
        }
    }
}
