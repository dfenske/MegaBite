using MegaBite.Operational.Error;
using MegaBite.Operational.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaBite.Data.Model
{
    public class DataCommon
    {
        #region Methods

        /// <summary>
        /// Handles the error and returns a new error with the client friendly message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public MBException HandleError(Exception exception)
        {
            //Check if exception is of type MB Exception
            MBException mb = exception as MBException;
            if (mb == null)
            {
                mb = new MBException(ErrorMessages.Unhandled_ErrorMessage, ErrorReason.Unhandled, new Dictionary<string, string>(), exception);
            }
            return mb;

        }
        #endregion
    }
}
