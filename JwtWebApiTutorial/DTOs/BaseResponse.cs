namespace JwtWebApiTutorial.DTOs
{
    /// <summary>
    /// Abstract model to represent base response   
    /// </summary>    
    public abstract class BaseResponse
    {
        #region Public Properties -----------------------------------------------------------------
        /// <summary>
        /// Message
        /// </summary>

        public string Message { get; set; }

        /// <summary>
        /// Message details
        /// </summary>
        public string MessageDetails { get; set; }

        /// <summary>
        /// Last accessed date and time
        /// </summary>
        public DateTime LastAccessedDateTime { get; set; }

        /// <summary>
        /// Success flag
        /// </summary>
        public bool IsSuccess { get; set; }

        #endregion Public Properties
    }


}
