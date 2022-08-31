using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudKitSharp.Core.Model
{
    /// <summary>
    /// Record Fetch Error Dictionary
    /// The error dictionary describing a failed operation with the following keys:
    /// </summary>
    /// <see cref="https://developer.apple.com/library/archive/documentation/DataManagement/Conceptual/CloudKitWebServicesReference/ModifyRecords.html#//apple_ref/doc/uid/TP40015240-CH2-SW7"/>
    public class RecordFetchErrorDictionary
    {
        /// <summary>
        /// The name of the record that the operation failed on.
        /// </summary>
        [JsonPropertyName("recordName")]
        public string? recordName { get; set; }

        /// <summary>
        /// A string indicating the reason for the error.
        /// </summary>
        [JsonPropertyName("reason")]
        public string? reason { get; set; }

        /// <summary>
        /// A string containing the code for the error that occurred. For possible values, see Error Codes.
        /// </summary>
        [JsonPropertyName("serverErrorCode")]
        public string? serverErrorCode { get; set; }

        /// <summary>
        /// The suggested time to wait before trying this operation again. If this key is not set, the operation can’t be retried.
        /// </summary>
        [JsonPropertyName("retryAfter")]
        public string? retryAfter { get; set; }

        /// <summary>
        /// A unique identifier for this error.
        /// </summary>
        [JsonPropertyName("uuid")]
        public string? uuid { get; set; }

        /// <summary>
        /// A redirect URL for the user to securely sign in using their Apple ID. This key is present when serverErrorCode is AUTHENTICATION_REQUIRED.
        /// </summary>
        [JsonPropertyName("redirectURL")]
        public string? redirectURL { get; set; }

    }
}
