using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI
{
    public interface IObjectURL
    {
        string URL { get; }
    }


    public abstract class ObjectID <T> : IObjectURL
        where T : ObjectID<T>
    {
        [JsonPropertyName("@id")]
        public string URL { get; set; }

        public Task< T> GetObject()
        {
            HttpClient client = new HttpClient();
            return GetObject(client);
        }

        public async Task<T> GetObject(HttpClient httpClient)
        {
            if(ObjectIsConstructed())
            {
                return GetThis();
            }
            HttpResponseMessage responseMessage = await httpClient.GetAsync(URL).ConfigureAwait(false);
            SingleObject value = await JsonSerializer.DeserializeAsync<SingleObject>(await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)).ConfigureAwait(false);
            return value.Value;
        }

        protected abstract T GetThis();


        public abstract bool ObjectIsConstructed();

        public class SingleObject
        {
            [JsonPropertyName("items")]
            public T Value { get; set; }   
        }

    }

    public class URLObject<T> : IObjectURL
    {
        public URLObject(Uri uRL)
        {
            URL = uRL;
        }

        public Uri URL { get; }

        string IObjectURL.URL => URL.AbsolutePath;

        public async Task<T> GetObject()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(URL).ConfigureAwait(false);
            T value = await JsonSerializer.DeserializeAsync<T>(await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)).ConfigureAwait(false);
            return value;
        }

    }

    public class URLToObjectConverter<T> : JsonConverter<URLObject<T>>
    {
        public override URLObject<T> Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var rootElement = JsonDocument.ParseValue(ref reader);

            // if its array return new instance or null
            if (reader.TokenType == JsonTokenType.String)
            {
                var text = rootElement.RootElement.GetRawText();
                return new URLObject<T>(new Uri(text, UriKind.RelativeOrAbsolute));
            }
            else
            {
                throw new NotSupportedException();
                var text = rootElement.RootElement.GetRawText();
                //return JsonSerializer.Deserialize<T>(text, options);
            }
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override void Write(Utf8JsonWriter writer, URLObject<T> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }

    public class URLIDToObjectConverter<T> : JsonConverter<T>
        where T : ObjectID<T>, new()
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var rootElement = JsonDocument.ParseValue(ref reader);

            // if its array return new instance or null
            if (reader.TokenType == JsonTokenType.String)
            {
                var text = rootElement.RootElement.GetRawText();
                return new T()
                {
                    URL = text,
                };
                //return default(T); // if you want null value instead of new instance
                //return (T) Activator.CreateInstance(typeof(T));
            }
            else
            {
                var text = rootElement.RootElement.GetRawText();
                return JsonSerializer.Deserialize<T>(text, options);
            }
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize<T>(writer, value, options);
        }
    }
}
