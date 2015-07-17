using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace 诱导跳转.Controllers
{
    public class RandomController : Controller
    {
        //
        // GET: /Random/

        public ActionResult Index(string uid="5400",string pid="a42") //控制生成随机链接
        {
            StringBuilder sb = GetRandStr();
            string url = string.Empty;
            XDocument doc = XDocument.Load(HttpContext.Server.MapPath("~/App_Data/random.xml"));
            var q = from d in doc.Descendants("app")
                    select d;
            url = q.Where(a => a.Element("uid").Value == uid && a.Element("pid").Value == pid).FirstOrDefault().Element("url").Value;
            //foreach (var item in q)
            //{
            //    if (item.Element("uid").Value == uid && item.Element("pid").Value == pid)
            //    {
            //        url = item.Element("url").Value + sb.ToString() + ".apk";
            //        break;
            //    }
            //    else
            //    {
            //        url = "http://www.anzhuangba.com";
            //    }
            //}
            if (string.IsNullOrEmpty(url))
            {
                url = "http://www.anzhuangba.com";
            }
            else
            {
                url += sb.ToString() + ".apk";
            }
            return Redirect(url);
        }

        public ActionResult Raw(string uid = "5400", string pid = "a42")  //普通链接
        {
            string url = string.Empty;
            XDocument doc = XDocument.Load(HttpContext.Server.MapPath("~/App_Data/random.xml"));
            var q = from d in doc.Descendants("app") select d;
            url = q.Where(a => a.Element("uid").Value == uid && a.Element("pid").Value == pid).FirstOrDefault().Element("url").Value;
            //foreach (var item in q)
            //{
            //    if (item.Element("uid").Value == uid && item.Element("pid").Value == pid)
            //    {
            //        url = item.Element("url").Value;
            //        break;
            //    }
            //    else
            //    {
            //        url = "http://www.anzhuangba.com";
            //    }
            //}
            if (string.IsNullOrEmpty(url))
            {
                url = "http://www.anzhuangba.com";
            }
            return Redirect(url);
        }
           

        private static StringBuilder GetRandStr()
        {
            string src = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; //字符串素材
            Random r = new Random();
            StringBuilder sb = new StringBuilder(); //用来构造随机字符串
            for (int i = 0; i < 8; i++)
            {
                sb.Append(src.Substring(r.Next(0, src.Length - 1), 1));
            }
            return sb;
        }
    }
}
