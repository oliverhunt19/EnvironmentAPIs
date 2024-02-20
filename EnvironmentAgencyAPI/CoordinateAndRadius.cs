using UnitsNet;

namespace EnvironmentAgencyAPI
{
    public struct CoordinateAndRadius
    {
        public LatLng Centre { get; set; }

        public Length Radius { get; set; }
    }
}
