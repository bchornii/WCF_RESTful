using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace MyRESTService
{
    public class WebFaultErrorHandler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return error is WebFaultException;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            WebFaultException exc = error as WebFaultException;
            if (exc != null)
            {
                fault = Message.CreateMessage(version, null, new UserErrorBodyWriter(error));
                fault.Properties[WebBodyFormatMessageProperty.Name] = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
                WebOperationContext.Current.OutgoingResponse.StatusCode = exc.StatusCode;
            }
        }
    }
}