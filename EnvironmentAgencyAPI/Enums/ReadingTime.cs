using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Enums
{
    public enum ReadingTime
    {
        [EnumMember(Value = "today")]
        Today,

        [EnumMember(Value = "latest")]
        Latest
    }
}
