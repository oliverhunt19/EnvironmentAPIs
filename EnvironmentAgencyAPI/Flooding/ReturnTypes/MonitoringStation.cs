using HttpWebAPICore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.ReturnTypes
{
    public class MonitoringStation
    {
        [JsonConverter(typeof(ArrayStringToObjectConverter<string>))]
        [JsonPropertyName("@id")]
        public ArrayValueType<string> Id { get; set; }

        //[JsonConverter(typeof(ArrayStringToObjectConverter<string>))]
        // the above is a possible fix to the array propblem, or I just ignore it
        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        public string RLOIid { get; set; }


        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<DateTime>))]
        [JsonPropertyName("dateOpened")]
        public DateTime DateOpened { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<DateTime?>))]
        [JsonPropertyName("statusDate")]
        public DateTime? StatusDate { get; set; }


        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        [JsonPropertyName("riverName")]
        public string RiverName { get; set; }


        [JsonConverter(typeof(ArrayToObjectConverter<double>))]
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }


        [JsonConverter(typeof(ArrayToObjectConverter<double>))]
        [JsonPropertyName("long")]
        public double Longitude { get; set; }


        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        [JsonPropertyName("notation")]
        public string Notation { get; set; }


        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        [JsonPropertyName("stationReference")]
        public string StationReference { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        [JsonPropertyName("wiskiID")]
        public string WISKI_ID { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<string>))]
        [JsonPropertyName("town")]
        public string Town { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<string?>))]
        [JsonPropertyName("catchmentName")]
        public string? CatchmentName { get; set; }

        //[JsonConverter(typeof(EmptyArrayToObjectConverter<IEnumerable<StationMeasures>>))]
        [JsonPropertyName("measures")]
        public IEnumerable<StationMeasures>? StationMeasures { get; set; }

        [JsonConverter(typeof(ArrayToObjectConverter<StationStatus?>))]
        [JsonPropertyName("status")]
        public StationStatus? Status { get; set; }

        [JsonConverter(typeof(StringObjectConverter<StationScale>))]
        [JsonPropertyName("stageScale")]
        public StationScale StageScale { get; set; }

        [JsonConverter(typeof(StringObjectConverter<StationScale>))]
        [JsonPropertyName("downstageScale")]
        public StationScale DownstageScale { get; set; }
    }

    public class ArrayToObjectConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var rootElement = JsonDocument.ParseValue(ref reader);

            // if its array return new instance or null
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                var text = rootElement.RootElement.GetRawText();
                T[] values = JsonSerializer.Deserialize<T[]>(text, options);
                return values.FirstOrDefault();
                return default; // if you want null value instead of new instance
                //return (T) Activator.CreateInstance(typeof(T));
            }
            else
            {
                var text = rootElement.RootElement.GetRawText();
                return JsonSerializer.Deserialize<T>(text, options);
            }
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

    public class ArrayStringToObjectConverter<T> : JsonConverter<ArrayValueType<T>>
    {
        public override ArrayValueType<T> Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var rootElement = JsonDocument.ParseValue(ref reader);

            // if its array return new instance or null
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                var text = rootElement.RootElement.GetRawText();
                return new ArrayValueType<T>(JsonSerializer.Deserialize<T[]>(text, options));
                //return default(T); // if you want null value instead of new instance
                //return (T) Activator.CreateInstance(typeof(T));
            }
            else
            {
                var text = rootElement.RootElement.GetRawText();
                return new ArrayValueType<T>(JsonSerializer.Deserialize<T>(text, options));
            }
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override void Write(Utf8JsonWriter writer, ArrayValueType<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize<T>(writer, value, options);
        }
    }
}
