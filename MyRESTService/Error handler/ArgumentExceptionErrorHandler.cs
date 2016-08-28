using System;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace MyRESTService
{
    public class ArgumentExceptionErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return error is ArgumentException;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            ArgumentException exc = error as ArgumentException;
            if (exc != null)
            {
                fault = Message.CreateMessage(version, null, new UserErrorBodyWriter(error as ArgumentException));
                fault.Properties[WebBodyFormatMessageProperty.Name] = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
            }
        }
    }
}