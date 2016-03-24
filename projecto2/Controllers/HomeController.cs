using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projecto2.MyEngines;
using projecto2.Models;
namespace projecto2.Controllers
{
    public class HomeController : Controller
    {
        ProjectO1Entities db = new ProjectO1Entities();
        public ActionResult Index()
        {
            MyDynamicEngine engine = new MyDynamicEngine();
            string post_id = engine.getValue("HOME_PAGE");
            if (post_id == null)
            {
                return HttpNotFound("Chưa cài đặt homepage");
            }
            int id = Int16.Parse(post_id);
            Post post = db.Post.SingleOrDefault(t => t.Id == id);
            return View(post);
        }

        public ActionResult Post(int id)
        {
            Post post = db.Post.SingleOrDefault(t => t.Id == id);
            return View(post);
        }

    }
}