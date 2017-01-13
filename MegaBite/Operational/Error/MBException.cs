using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Operational.Error
{
    public class MBException : ApplicationException
    {
        #region Fields
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the error reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public ErrorReason Reason
        { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details. 
        /// </value>
        /// <remarks>
        /// Key = field name that failed validation. 
        /// Value = error message.
        /// </remarks>
        public Dictionary<string, string> Details
        { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MBException"/> class.
        /// </summary>
        public MBException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MBException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public MBException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MBException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public MBException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MBException"/> class.
        /// </summary>
        /// <param name="message">The geneeral message or title for this error.</param>
        /// <param name="reason">The reason the error was thrown.</param>
        /// <param name="details">The additional details describing what went wrong.</param>
        /// <param name="innerException">The inner exception.</param>
        public MBException(string message, ErrorReason reason, Dictionary<string, string> details, Exception innerException) : base(message, innerException)
        {
            this.Reason = reason;
            this.Details = details;
        }

        #endregion
    }
}
