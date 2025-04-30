using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reservation
{
    /// <summary>
    /// Represents a response object used for API communication.
    /// This class is used to structure the response data sent back to clients,
    /// containing reservation-related information in a key-value format.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Dictionary containing reservation information.
        /// Keys represent the type of information, values contain the actual data.
        /// </summary>
        public Dictionary<string, string> reservationInfo = new Dictionary<string, string>();

        /// <summary>
        /// Creates a new empty response object
        /// </summary>
        public Response()
        {
        }
    }
}