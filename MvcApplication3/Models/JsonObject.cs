using System;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace MvcApplication3.Models
{
    [DataContract]
    public class Data
    {
        [DataMember]
        public decimal dstOffset { get; set; }
        [DataMember]
        public decimal rawOffset { get; set; }
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string timeZoneId { get; set; }
        [DataMember]
        public string timeZoneName { get; set; }
    }

    public class JsonObject : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.LogRequest += new EventHandler(OnLogRequest);
        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //custom logging logic can go here
        }
    }
}
