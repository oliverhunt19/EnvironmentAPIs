using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Enums
{
    public enum MeasurementType
    {
        //[StringValue("level")]
        [EnumMember(Value = "level")]
        WaterLevel,

        //[StringValue("flow")]
        [EnumMember(Value = "flow")]
        Flow,

        //[StringValue("wind")]
        [EnumMember(Value = "wind")]
        Wind,

        //[StringValue("temperature")]
        [EnumMember(Value = "temperature")]
        Temperature,

        //[StringValue("rainfall")]
        [EnumMember(Value = "rainfall")]
        Rainfall
    }
}
