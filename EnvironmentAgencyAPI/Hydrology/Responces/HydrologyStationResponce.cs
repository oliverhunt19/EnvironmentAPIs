﻿using EnvironmentAgencyAPI.Hydrology.Requests;
using HttpWebAPICore.BaseClasses;
using System.Text.Json.Serialization;

namespace EnvironmentAgencyAPI.Hydrology.Responces
{
    public class HydrologyStationResponce : BaseResponse<HydrologyStationRequest>
    {
        [JsonPropertyName("items")]
        public IEnumerable<HydrologyStation> HydrologyStation { get; set; }
    }
}
