using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentAgencyAPI.Hydrology.Requests
{
    public class HydrologyMeasuresRequest : HydrologyBaseRequest
    {
        protected override string RequestRootString => "id/measures";
    }
}
