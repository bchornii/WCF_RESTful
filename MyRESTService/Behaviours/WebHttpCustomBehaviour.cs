using System;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;

namespace MyRESTService
{
    public class WebHttpCustomBehaviour : WebHttpBehavior
    {
        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            int errorHanlerCount = endpointDispatcher.ChannelDispatcher.ErrorHandlers.Count;
            base.AddServerErrorHandlers(endpoint, endpointDispatcher);
            IErrorHandler webHttpErrorHandler = endpointDispatcher.ChannelDispatcher.ErrorHandlers[errorHanlerCount];
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.RemoveAt(errorHanlerCount);

            GenericErrorHandler newHandler = new GenericErrorHandler(webHttpErrorHandler);
            newHandler.UserErrorHadlersColletion[typeof(ValidationException)] = new ValidationErrorHadler();
            newHandler.UserErrorHadlersColletion[typeof(Exception)] = new ExceptionErrorHandler();
            newHandler.UserErrorHadlersColletion[typeof(WebFaultException)] = new WebFaultErrorHandler();
            newHandler.UserErrorHadlersColletion[typeof(ArgumentException)] = new ArgumentExceptionErrorHandler();
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(newHandler);
        }

        public override void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            base.ApplyDispatchBehavior(endpoint, endpointDispatcher);
            foreach (DispatchOperation operation in endpointDispatcher.DispatchRuntime.Operations)
            {
                operation.ParameterInspectors.Add(new ValidatingParameterInspector());
            }
        }
    }
}