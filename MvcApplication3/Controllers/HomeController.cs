using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MvcApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string MyString = ViewBag.Message =  "Please enter a location";
            
            return View();
        }

        [HttpPost]
        public ActionResult SendRestRequest(decimal latitude, decimal longitude)
        {
            
                var stopwatch = new System.Diagnostics.Stopwatch();
                
                 
               
                    // fetch data (as JSON string)
                    string uri = ""; 
                           uri = uri + "https://maps.googleapis.com/maps/api/timezone/json?location="
                                 + latitude.ToString()
                                 + ","
                                 + longitude.ToString()
                                 + "&timestamp=1331161200"
                                 + "&key=AIzaSyDq7uE5UVW_zceDNiLgCj8vxUA5ku9jg6g";

                           
                    var url = new Uri(uri);
                    var client = new System.Net.WebClient();
                    var json = client.DownloadString(url);

                    // deserialize JSON into objects
                    var serializer = new JavaScriptSerializer();
                    var data = serializer.Deserialize<Models.Data>(json);
          
                    // use the objects
                    decimal DstOffset = data.dstOffset;
                    decimal RawOffset = data.rawOffset;

                    DateTime theTime = HttpContext.Timestamp;
                    
                    ViewBag.jsonDstOffset = data.dstOffset;
                    ViewBag.jsonRawOffset = data.rawOffset;
                    ViewBag.jsonStatus = data.status;
                    ViewBag.jsonTimeZoneId = data.timeZoneId;
                    ViewBag.jsonTimeZoneName = data.timeZoneName;
                    ViewBag.thetime = theTime;
                    ViewBag.latitudeNumber = "";
                    ViewBag.longitudeNumber = "";
                   
            return View();
        }

    }

    
}
