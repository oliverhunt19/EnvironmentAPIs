using HttpWebAPICore;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Flooding.ReturnTypes
{
    public class StationMeasures
    {
        [JsonPropertyName("parameter")]
        public string Parameter { get; set; }

        [JsonPropertyName("period")]
        public double Period { get; set; }

        [JsonPropertyName("qualifier")]
        public string Qualifier { get; set; }

        [JsonPropertyName("unitName")]
        public string UnitName { get; set; }

        [JsonConverter(typeof(StringObjectConverter<Reading>))]
        public Reading latestReading { get; set; }

        [JsonPropertyName("stationReference")]
        public string StationReference { get; set; }
    }

    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            StringValue = value;
        }

        #endregion

    }
}
