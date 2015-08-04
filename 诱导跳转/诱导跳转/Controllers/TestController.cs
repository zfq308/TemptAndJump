using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace 诱导跳转.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index(string uid)
        {
            ViewBag.Url = GetInfoFromXml(uid);
            return View();
        }

        private string GetInfoFromXml(string uid = "9v") //从xml配置文件中取出下载链接
        {
            string result = string.Empty;
            XDocument doc = XDocument.Load(HttpContext.Server.MapPath("~/App_Data/testurl.xml"));
            var q = from d in doc.Descendants("test") select d;
            result = q.Where(a => a.Element("company").Value == uid).FirstOrDefault().Element("url").Value;
            return result;
        }
    }
}
