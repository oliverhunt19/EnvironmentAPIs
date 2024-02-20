using GoogleApi.Entities.Common.Extensions;

namespace EnvironmentAgencyAPI
{
    internal static class Helpers
    {
        public static void AddCentreAndRadius(this CoordinateAndRadius coordinateAndRadius, IList<KeyValuePair<string, string?>> parameters)
        {
            parameters.Add("lat", coordinateAndRadius.Centre.Lat.DecimalDegrees.ToString());
            parameters.Add("long", coordinateAndRadius.Centre.Lng.DecimalDegrees.ToString());
            parameters.Add("dist", coordinateAndRadius.Radius.Kilometers.ToString());
        }
    }
}
