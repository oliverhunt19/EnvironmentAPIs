using EnvironmentAgencyAPI.Enums;

using HttpWebAPICore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPITests.TestEnums
{
    [TestClass]
    public class TestEnumSerialisation
    {
        JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
        {
            new EnumJsonConverterFactory(JsonNamingPolicy.CamelCase, true),
            //new StringObjectConverterFactory(),
        },
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

        };

        [TestMethod]
        public async Task TestMeasurmentTypeSerialisation()
        {
            MeasurementType measurementType = MeasurementType.WaterLevel;

            string serialised = JsonSerializer.Serialize(measurementType, jsonSerializerOptions);

            var measure = JsonSerializer.Deserialize<MeasurementType>(serialised, jsonSerializerOptions);
        }
    }
}
