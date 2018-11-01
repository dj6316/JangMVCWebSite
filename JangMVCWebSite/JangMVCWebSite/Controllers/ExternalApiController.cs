using JangMVCWebSite.Libs.Service.Api;
using System.Web.Mvc;

namespace JangMVCWebSite.Controllers
{
    public class ExternalApiController : Controller
    {
        public ActionResult DirectSendView()
        {
            return PartialView();
        }

        public ActionResult Maps()
        {
            return PartialView();
        }

        public ActionResult MSXMLType()
        {
            return Json(new { result = new DirectSendMailApiService().SendServerXmlHttp() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HttpWebRequestType()
        {
            return Json(new { result = new DirectSendMailApiService().SendHttpWebRequest() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult WebClientType()
        {
            return Json(new { result = new DirectSendMailApiService().SendWebClient() }, JsonRequestBehavior.AllowGet);
        }
    }
}