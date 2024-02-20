namespace EnvironmentAgencyAPI.Flooding.ReturnTypes
{
    public class StationScale
    {
        /// <summary>
        /// The highest reading for this measurement in recent times (typically the last 5 years)
        /// </summary>
        public Reading highestRecent { get; set; }

        /// <summary>
        /// The highest reading for this measurement on record
        /// </summary>
        public Reading maxOnRecord { get; set; }

        /// <summary>
        /// The lowest reading for this measurement on record
        /// </summary>
        public Reading minOnRecord { get; set; }

        /// <summary>
        /// The top of the typical range band - the measurement exceeded this for 5% of the relevant data on record
        /// </summary>
        public double typicalRangeHigh { get; set; }

        /// <summary>
        /// The bottom of the typical range band - the measurement exceeded this for 95% of the relevant data on record
        /// </summary>
        public double typicalRangeLow { get; set; }
    }
}
