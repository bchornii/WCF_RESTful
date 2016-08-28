using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Collections.Generic;

namespace MyRESTService
{
    public class GenericErrorHandler : IErrorHandler
    {
        IErrorHandler originalErrorHandler;
        public Dictionary<Type,IErrorHandler> UserErrorHadlersColletion { get; private set; }
        public GenericErrorHandler(IErrorHandler originalErrorHandler)        
        {
            this.originalErrorHandler = originalErrorHandler;
            UserErrorHadlersColletion = new Dictionary<Type, IErrorHandler>();
        }
        public bool HandleError(Exception error)
        {
            return UserErrorHadlersColletion.ContainsKey(error.GetType()) ?
                   UserErrorHadlersColletion[error.GetType()].HandleError(error) :
                   originalErrorHandler.HandleError(error);            
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {            
            if (UserErrorHadlersColletion.ContainsKey(error.GetType()))
            {
                UserErrorHadlersColletion[error.GetType()].ProvideFault(error, version, ref fault);                
            }
            else
            {
                originalErrorHandler.ProvideFault(error, version, ref fault);
            }
        }
    }                      
}