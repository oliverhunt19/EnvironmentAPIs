using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Converters;
using EnvironmentAgencyAPI.Enums;
using FluentAssertions;
using EnvironmentAgencyAPI.Flooding.Requests.ReadingRequest;

namespace EnvironmentAgencyAPITests.FunctionalTests
{
    [TestClass]
    public class TestReadingsResponce
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.ReadingsAPI readingsAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.ReadingsAPI();
            ReadingsRequest request = new ReadingsRequest(ReadingTime.Today) { ViewFull = true, Limit= 500 };
            var responce = await readingsAPI.QueryAsync(request);

            foreach(var reading in responce.Readings)
            {
                reading.dateTime.Date.Should().Be(DateTime.Now.Date);
            }
        }

        [TestMethod]
        public async Task TestReadingsToday_DateShouldBeToday()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.ReadingsAPI readingsAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.ReadingsAPI();
            StationReadingsRequest request = new StationReadingsRequest("E71333", ReadingTime.Today) { ViewFull = true };
            var responce = await readingsAPI.QueryAsync(request);

            foreach(var date in responce.Readings.Select(x => x.dateTime.Date))
            {
                date.Should().Be(DateTime.Now.Date);
            }
        }

        [TestMethod]
        public async Task TestReadingsLatest()
        {
            EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.ReadingsAPI readingsAPI = new EnvironmentAgencyAPI.Flooding.EnvironmentAgencyAPI.ReadingsAPI();
            StationReadingsRequest request = new StationReadingsRequest("E71333", ReadingTime.Latest) { ViewFull = true };
            var responce = await readingsAPI.QueryAsync(request);

            foreach (var date in responce.Readings.Select(x => x.dateTime.Date))
            {
                date.Should().Be(DateTime.Now.Date);
            }

            // Should only be 1 reading
            responce.Readings.Count().Should().Be(1);

            // Latest reading should be within the last hour 
            TimeSpan diff = DateTime.Now - responce.Readings.First().dateTime;
            diff.Should().BeLessThan(TimeSpan.FromHours(1));
        }
    }
}
