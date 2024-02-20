using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Hydrology.Requests
{
    public class HydrologyStationRequest : HydrologyBaseRequest
    {
        public string StationReference { get; }
        protected override string RequestRootString => $"id/stations/{StationReference}";

        public HydrologyStationRequest(string stationReference)
        {
            if (string.IsNullOrEmpty(stationReference))
            {
                throw new ArgumentNullException(nameof(stationReference));
            }
            StationReference = stationReference;
        }
    }
}
