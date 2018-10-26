using JangMVCWebSite.Models.CommonParam;
using JangMVCWebSite.Service.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JangMVCWebSite.Controllers
{
    public class ExternalApiController : Controller
    {
        public ActionResult ApiTest()
        {
            return View();
        }

        public ActionResult MSXMLType()
        {
            return Json(new { result = new DirectSendMailApiService().SendServerXmlHttp() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HttpWebRequestType()
        {
            return Json(new { result = new DirectSendMailApiService().SendHttpWebRequest(), JsonRequestBehavior.AllowGet });
        }
        public JsonResult WebClientType()
        {
            return Json(new { result = new DirectSendMailApiService().SendWebClient(), JsonRequestBehavior.AllowGet });
        }
    }
}