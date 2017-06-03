using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.ViewModels;
using EShop.BLL.Interfaces;

namespace EShop.WebBack.Controllers
{
    public class CategoriesSubController : Controller
    {
        ICategorySubService _serviceCS;
        ICategoryService _serviceC;
        public CategoriesSubController(ICategorySubService serviceCS,
                                       ICategoryService serviceC)
        {
            _serviceCS = serviceCS;
            _serviceC = serviceC;
        }


        // GET: CategoriesSub
        public ActionResult Index()
        {
            //Select List
            var categorylist = _serviceC.GetAllCateogryList();

            //使用Extension方法
            var selectlist = categorylist.ToSelectList(v => v.CategoryID, n => n.CategoryName, 1);

            ViewBag.CategorySelectList = selectlist;

            return View();
        }

        public PartialViewResult CategorySubPartial(int CategoryID = 1) //預設帶分類編號1
        {
            var categorylist = _serviceCS.GetCategorySubList(CategoryID);
            return PartialView(categorylist);
        }



        //GET: CategoriesSub/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categorySub = _serviceCS.GetCategorySubByID((int)id);
            if (categorySub == null)
            {
                return HttpNotFound();
            }
            return View(categorySub);
        }

        // GET: CategoriesSub/Create
        public ActionResult Create()
        {
            var categorylist = _serviceC.GetAllCateogryList();
            var selectlist = categorylist.ToSelectList(v => v.CategoryID, n => n.CategoryName);

            ViewBag.CategorySelectList = selectlist;
            return View();
        }

        // POST: CategoriesSub/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategorySubID,CategoryID,CategoryNameSub,Description")] CategorySubViewModel categorySub)
        {
            if (ModelState.IsValid)
            {
                bool isSave = _serviceCS.AddCategorySub(categorySub);

                return RedirectToAction("Index");
            }

            var categorylist = _serviceC.GetAllCateogryList();
            ViewBag.CategorySelectList = categorylist.ToSelectList(v => v.CategoryID, n => n.CategoryName ,categorySub.CategorySubID);

            return View(categorySub);
        }

        // GET: CategoriesSub/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categorySub = _serviceCS.GetCategorySubByID((int)id);
            if (categorySub == null)
            {
                return HttpNotFound();
            }
            var categorylist = _serviceC.GetAllCateogryList();
            var selectlist = categorylist.ToSelectList(v => v.CategoryID, n => n.CategoryName, categorySub.CategoryID);

            ViewBag.CategorySelectList = selectlist;
            return View(categorySub);
        }

        // POST: CategoriesSub/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategorySubID,CategoryID,CategoryNameSub,Description")] CategorySubViewModel categorySub)
        {
            if (ModelState.IsValid)
            {
                bool isSave = _serviceCS.UpdateCategorySub(categorySub);

                return RedirectToAction("Index");
            }

            var categorylist = _serviceC.GetAllCateogryList();
            ViewBag.CategoryID = categorylist.ToSelectList(v => v.CategoryID, n => n.CategoryName , categorySub.CategorySubID);

            return View(categorySub);
        }

        // GET: CategoriesSub/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categorySub = _serviceCS.GetCategorySubByID((int)id);
            if (categorySub == null)
            {
                return HttpNotFound();
            }
            return View(categorySub);
        }

        // POST: CategoriesSub/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool isSave = _serviceCS.DeleteCategorySub((int)id);

            return RedirectToAction("Index");
        }


    }
}
