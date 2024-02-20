using System.Runtime.Serialization;

namespace EnvironmentAgencyAPI.Flooding.ReturnTypes
{
    public enum StationStatus
    {
        [EnumMember(Value = "http://environment.data.gov.uk/flood-monitoring/def/core/statusActive")]
        Active,
        [EnumMember(Value = "http://environment.data.gov.uk/flood-monitoring/def/core/statusClosed")]
        Closed,
        [EnumMember(Value = "http://environment.data.gov.uk/flood-monitoring/def/core/statusSuspended")]
        Suspended,

        [EnumMember(Value = "http://environment.data.gov.uk/flood-monitoring/def/core/statusukcmf")]
        UKCMF,

    }
}
