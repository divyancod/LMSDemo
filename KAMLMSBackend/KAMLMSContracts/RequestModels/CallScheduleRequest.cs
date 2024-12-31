namespace KAMLMSContracts.RequestModels
{
    /// <summary>
    /// CallSchedule Request class for call related details
    /// </summary>
    public class CallScheduleRequest
    {
        /// <summary>
        /// Company Id or lead id for which call is being scheduled
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// POC id for which call is getting scheduled
        /// </summary>
        public string PocId { get; set; }
        /// <summary>
        /// Datetime at what time call is being scheduled
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// Any addition comment or reason for the call? (Followup, introducation)
        /// </summary>
        public string? Comment { get; set; }
        /// <summary>
        /// call frequency
        /// </summary>
        public int CallFrequency { get; set; }
    }
    /// <summary>
    /// This is for list call schuedle list with the filters
    /// </summary>
    public class CallFilters
    {
        /// <summary>
        /// Requested status of the call which is demanded by the UI 
        /// </summary>
        public List<int>? statusList { get; set; }
    }
}
