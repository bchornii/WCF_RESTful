using MyRESTService.Error_handler;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace MyRESTService
{
    public class ValidationErrorHadler : IErrorHandler
    {
        public bool HandleError(Exception error)
        {
            return error is ValidationException;
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            ValidationException validationException = error as ValidationException;
            if (validationException != null)
            {
                fault = Message.CreateMessage(version, null, new ValidationErrorBodyWriter(validationException));
                fault.Properties[WebBodyFormatMessageProperty.Name] = new WebBodyFormatMessageProperty(WebContentFormat.Json);
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
            }
        }
    }
}