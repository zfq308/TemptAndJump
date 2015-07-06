using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using 诱导跳转.Models;


namespace 诱导跳转.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Random r = new Random();

        public ActionResult Index(string uid="5400",string pid="a42")
        {
            PackageInfo pack = new PackageInfo();
            pack.Uid = uid;
            pack.Pid = pid;
            pack.Url = GetUrlFromXml(pack.Uid, pack.Pid);
            ViewBag.TopImg = SetImgName(true); //设置顶部图片名
            #region 设置图片名
            ViewBag.Img2 = SetImgName(false);
            ViewBag.Img3 = SetImgName(false);
            ViewBag.Img4 = SetImgName(false);
            ViewBag.Img5 = SetImgName(false);
            ViewBag.Img1 = SetImgName(false); 
            #endregion

            return View(pack);
        }

        private int SetImgName(bool istop) //随机设置图片
        {
            if (istop)
            {
                return r.Next(101, 105);
            }
            else
            {
                return r.Next(0, 30);
            }
        }

        private string GetUrlFromXml(string uid, string pid) //从xml配置文件中取出下载链接
        {
            var url = string.Empty;
            XDocument doc = XDocument.Load(HttpContext.Server.MapPath("~/App_Data/config.xml"));
            var q = from d in doc.Descendants("app") select d;
            foreach (var item in q)
            {
                if (item.Element("uid").Value == uid && item.Element("pid").Value == pid)
                {
                    url = item.Element("url").Value;
                    break;
                }
                else
                {
                    url = "http://www.anzhuangba.com";
                }
            }
            return url;
        }

    }
}
