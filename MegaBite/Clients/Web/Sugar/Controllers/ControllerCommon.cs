using MegaBite.Domain.Model;
using MegaBite.Operational.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MegaBite.Clients.Web.Sugar.Controllers
{
    public class ControllerCommon : Controller
    {
        #region Methods

        /// <summary>
        /// Handles the error and updates the model state to return the errors to the client.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="model">The model that was involved with the error.</param>
        public ActionResult HandleError<T>(Exception exception, T model)
        {
            ActionResult response = null;

            MBException mb = exception as MBException;
            // Check if exception was already of type MBException. If not, wrap it in MBException.
            if (mb != null)
            {
                switch (mb.Reason)
                {
                    case ErrorReason.Validation:
                    case ErrorReason.WebAPI:
                        foreach (var mbItem in mb.Details)
                        {
                            ModelState.AddModelError(mbItem.Key, mbItem.Value);
                        }

                        // Check if the model is a primitive type.
                        if (!model.GetType().IsPrimitive)
                        {
                            // If model is reference type, check if it's inheriting from base object. This likely means we can return the model state to the view for the user to fix the error.
                            if (model.GetType().IsSubclassOf(typeof(BaseObject)))
                            {
                                response = View(model);
                            }
                            else
                            {
                                // If the model doesn't inherit from BaseObject, won't make sense to return the model to the view, so we return HTTPNotFound
                                response = HttpNotFound();
                            }
                        }
                        break;
                    case ErrorReason.Unknown:
                    case ErrorReason.Unhandled:
                    default:
                        response = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                        break;
                }
            }
            else
            {
                // TODO: fix exception handling
                response = new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        #endregion
    }
}