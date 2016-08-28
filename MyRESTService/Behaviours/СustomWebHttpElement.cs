using System;
using System.ServiceModel.Configuration;

namespace MyRESTService
{
    public sealed class CustomWebHttpElement : BehaviorExtensionElement
    {
        /*#region Type specific properties

        [ConfigurationProperty("defaultBodyStyle", DefaultValue = WebMessageBodyStyle.Bare)]
        public WebMessageBodyStyle DefaultBodyStyle
        {
            get { return (WebMessageBodyStyle)this["defaultBodyStyle"]; }

            set { this["defaultBodyStyle"] = value; }
        }

        [ConfigurationProperty("defaultOutgoingRequestFormat", DefaultValue = WebMessageFormat.Json)]
        public WebMessageFormat DefaultOutgoingRequestFormat
        {
            get { return (WebMessageFormat)this["defaultOutgoingRequestFormat"]; }

            set { this["defaultOutgoingRequestFormat"] = value; }
        }

        [ConfigurationProperty("defaultOutgoingResponseFormat", DefaultValue = WebMessageFormat.Json)]
        public WebMessageFormat DefaultOutgoingResponseFormat
        {
            get { return (WebMessageFormat)this["defaultOutgoingResponseFormat"]; }

            set { this["defaultOutgoingResponseFormat"] = value; }
        }

        #endregion*/

        #region Base class overrides

        protected override object CreateBehavior()
        {
            WebHttpCustomBehaviour result = new WebHttpCustomBehaviour();

            //result.DefaultBodyStyle = DefaultBodyStyle;
            //result.DefaultOutgoingRequestFormat = DefaultOutgoingRequestFormat;
            //result.DefaultOutgoingResponseFormat = DefaultOutgoingResponseFormat;
            return result;
        }

        public override Type BehaviorType
        {
            get { return typeof(WebHttpCustomBehaviour); }
        }

        #endregion
    }
}