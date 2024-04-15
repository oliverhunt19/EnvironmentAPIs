using GoogleApi.Entities.Common.Extensions;

namespace EnvironmentAgencyAPI
{
    internal static class Helpers
    {
        public static void AddCentreAndRadius(this CoordinateAndRadius coordinateAndRadius, IList<KeyValuePair<string, string?>> parameters)
        {
            parameters.Add("lat", coordinateAndRadius.Centre.Lat.Degrees.ToString());
            parameters.Add("long", coordinateAndRadius.Centre.Lng.Degrees.ToString());
            parameters.Add("dist", coordinateAndRadius.Radius.Kilometers.ToString());
        }
    }
}
