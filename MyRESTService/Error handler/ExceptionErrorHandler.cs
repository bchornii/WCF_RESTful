using System;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace MyRESTService
{
    public class ExceptionErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return error is Exception;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            Exception exc = error as Exception;
            if (exc != null)
            {
                fault = Message.CreateMessage(version, null, new UserErrorBodyWriter(error));
                fault.Properties[WebBodyFormatMessageProperty.Name] = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
            }
        }
    }
}