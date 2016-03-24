using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projecto2.Models;
using System.Threading.Tasks;
namespace projecto2.Controllers
{
    public class AdminController : Controller
    {
        ProjectO1Entities db = new ProjectO1Entities();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Thêm menu 
        /// </summary>
        /// <param name="display"></param>
        /// <param name="link"></param>
        /// <param name="parentId">if this is the first menu, this default value = -1</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> addHeadItem(string display, string link, int? parentId = null)
        {
            MenuItem item = db.MenuItem.Create();
            item.Link = link;
            item.Display = display;
            item.ParentMenuId = parentId;

            db.MenuItem.Add(item);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Sửa menu 
        /// </summary>
        /// <param name="display"></param>
        /// <param name="link"></param>
        /// <param name="parentId">if this is the first menu, this default value = -1</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> editHeadItem(int id, string display, string link, int? parentId = null)
        {
            MenuItem item = db.MenuItem.SingleOrDefault(t => t.Id == id);
            item.Link = link;
            item.Display = display;
            item.ParentMenuId = parentId;

            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Thêm bài viết 
        /// </summary>
        /// <param name="display"></param>
        /// <param name="link"></param>
        /// <param name="parentId">if this is the first menu, this default value = -1</param>
        /// <returns></returns>
        public ActionResult addPost()
        {
            return View();
        }
        /// <summary>
        /// Thêm bài viết 
        /// </summary>
        /// <param name="display"></param>
        /// <param name="link"></param>
        /// <param name="parentId">if this is the first menu, this default value = -1</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> addPost(string title, string content)
        {
            Post post = db.Post.Create();
            post.Title = title;
            post.Content = content;
            post.DateCreated = DateTime.Now;

            db.Post.Add(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Sửa bài viết 
        /// </summary>
        /// <param name="display"></param>
        /// <param name="link"></param>
        /// <param name="parentId">if this is the first menu, this default value = -1</param>
        /// <returns></returns>
        public ActionResult editPost(int Id)
        {
            Post post = db.Post.SingleOrDefault(t => t.Id == Id);
            return View(post);
        }


        /// <summary>
        /// Thêm bài viết 
        /// </summary>
        /// <param name="display"></param>
        /// <param name="link"></param>
        /// <param name="parentId">if this is the first menu, this default value = -1</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> editPost(int Id, string title, string content)
        {
            Post post = db.Post.SingleOrDefault(t => t.Id == Id);
            post.Title = title;
            post.Content = content;
            post.DateCreated = DateTime.Now;

            db.Entry(post).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}