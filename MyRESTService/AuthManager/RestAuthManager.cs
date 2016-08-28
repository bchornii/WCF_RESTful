using System.ServiceModel;
using System.ServiceModel.Web;

namespace MyRESTService
{
    public class RestAuthManager : ServiceAuthorizationManager
    {
        public override bool CheckAccess(OperationContext operationContext)
        {
            //var authHeader = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            //if(authHeader != null && authHeader != string.Empty)
            //{
            //    return true;
            //}
            //else
            //{
            //    WebOperationContext.Current.OutgoingResponse.Headers.Add("WWW-Authenticate", "Not autorized");
            //    throw new WebFaultException(System.Net.HttpStatusCode.Unauthorized);
            //}
            return true;
        }        
    }
}