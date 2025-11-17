using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _24DH110590_MyStore.Models;

namespace _24DH110590_MyStore.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // GET: Admin/Categories
        // GET : lấy dữ liệu từ bảng Categories trong DB để hiện thị lên
        public ActionResult Index()
        {
            try
            {
                var list = db.Categories.ToList();
                return View(list);
            }
            catch (Exception ex)
            {
                // Log for debugging
                System.Diagnostics.Trace.TraceError("Categories.Index error: {0}", ex);
                // Return HTTP 500 with the exception message so you can see it in the browser while debugging locally
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET: Admin/Categories/Details/5
        // Details : lấy chi tiết một bản ghi có  CategoryID = id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);  // khong tìm thấy  bản ghi
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound(); // mã lỗi 404 
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        // load form create
        // [HttpGet] là phương thức mặc dịnhd , nên không cần khai báo từ khóa 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // post : lưu dl vào  từ form  create vào DB
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        // lấy dữ liệu của một danh mục  đã có sao cho CategoryID = id 
        public ActionResult Edit(int? id)
        {
            //Details(id); có thể gọi hàm Details để tái sử dụng code
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
