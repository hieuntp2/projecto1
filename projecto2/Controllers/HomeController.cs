using System;
using System.Linq;
using System.Web.Mvc;
using projecto2.MyEngines;
using projecto2.Models;
using System.Threading.Tasks;
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

        public ActionResult contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> sendEmail(string email, string message)
        {
            GMailer gmail = new GMailer();
            string fromEmail = "vsourcesoftwaresolution@gmail.com";
            string password = "Admin01!";
            string toemail = "sales@vsource-software.com";
            //string toemail = "hieuntp2@gmail.com";
            await gmail.Send(fromEmail, password, toemail, "vSSS.com: New Message from website", email, message);
            return RedirectToAction("thankyou");
        }

        public ActionResult thankyou()
        {
            return View();
        }
    }
}