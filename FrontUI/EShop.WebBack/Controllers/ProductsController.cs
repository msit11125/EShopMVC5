using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.DAL.Repository;
using EShop.Models;
using EShop.BLL.Service;
using EShop.BLL.Interfaces;
using PagedList;
using EShop.ViewModels;
using System.IO;

namespace EShop.WebBack.Controllers
{
    [RoutePrefix("Products")]

    public class ProductsController : Controller
    {
        IProductService _serviceP;
        ICategoryService _serviceC;
        ICategorySubService _serviceCS;
        public ProductsController(IProductService serviceP,
                                  ICategoryService serviceC,
                                  ICategorySubService serviceCS)
        {
            _serviceP = serviceP;
            _serviceC = serviceC;
            _serviceCS = serviceCS;
        }



        public ActionResult Index()
        {
            var categoryList = _serviceC.GetAllCateogryList();
            ViewBag.CategorySelectList = categoryList.ToSelectList(v => v.CategoryID, n => n.CategoryName);

            return View();
        }


        /// <summary>
        /// 子類別下拉選單資料
        /// </summary>
        /// <param name="id">CategoryID</param>
        /// <returns></returns>
        public JsonResult GetCategorySubJson(int id)
        {
            if (id == 0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var categorySubList = _serviceCS.GetCategorySubList(id);
            return Json(categorySubList,JsonRequestBehavior.AllowGet);
        }



        // GET: Products
        public ActionResult PartialProductList(int? categorySubID, int? page,string sortColumnName = "ProductModel",string sort = "")
        {
            var pList = _serviceP.GetProductList((int)categorySubID);


            if (pList.Count() == 0)
            {
                var categorySub = _serviceCS.GetCategorySubByID((int)categorySubID);
                var pvm = new ProductViewModel() { CategorySubID = (int)categorySubID, CategorySub = categorySub };
                var pList2 = new List<ProductViewModel>();
                pList2.Add(pvm);
                return PartialView(pList2.ToPagedList(page ?? 1, 5));
            }

            //Memo 金額
            ViewBag.MemoPrice = new Func<decimal, string>(MemoPrice);

            return PartialView(pList.ToPagedList(page??1,5));
        }

        #region (Method) 判斷ViewBag.MemoPrice 金額邏輯判斷
        private string MemoPrice(decimal totalPrice)
        {
            if (totalPrice >= 100 && totalPrice < 500)
            {
                return "<span style=\"color: blue;\">超過100元</span>";
            }
            else if (totalPrice >= 500 && totalPrice < 1000)
            {
                return "<span style=\"color: green;\">超過500元</span>";
            }
            else if (totalPrice >= 1000)
            {
                return "<span style=\"color: red;\">超過1000元</span>";
            }
            else
            {
                return "<span style=\"color: black;\">不足100元</span>";
            }
        }
        #endregion



        //GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _serviceP.GetProductByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        //GET: Products/Create
        public PartialViewResult Create(int? categoryID ,int? categorySubID)
        {

            var categoryList = _serviceCS.GetCategorySubList((int)categoryID);
            ViewBag.CategorySubID = categoryList.ToSelectList(v => v.CategorySubID, n => n.CategoryNameSub, (int)categorySubID);

            return PartialView();
        }

        //// POST: Products/Create
        //// 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        //// 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductModel,ProductName,CategorySubID,UnitPrice,Photo,Description,Status,CreateDate,ModifyDate")] ProductViewModel product, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                //檔案上傳
                if (Photo != null)
                {
                    Photo.SaveAs(Request.PhysicalApplicationPath + @"Content\ProductImages\" + Photo.FileName);
                    //將檔案名稱放進 product.ProductImage (路徑名稱)
                    product.Photo = Photo.FileName;
                }
                //建立時間
                product.CreateDate = DateTime.Now;

                bool isSave = _serviceP.AddProduct(product);

                return Json(new { success = isSave });

            }
            int cateID = _serviceC.GetAllCateogryList().Where(c => c.CategoryID == product.CategorySubID).FirstOrDefault().CategoryID;
            var categoryList = _serviceCS.GetCategorySubList(cateID);
            ViewBag.CategorySubID = categoryList.ToSelectList(v => v.CategorySubID, n => n.CategoryNameSub, product.CategorySubID);

            return PartialView(product);
        }

        // GET: Products/Edit/5
        [HttpGet]
        [Route("Edit/{ProductID}")]
        public ActionResult Edit(int? ProductID) 
        {
            if (ProductID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _serviceP.GetProductByID((int)ProductID);
            if (product == null)
            {
                return HttpNotFound();
            }

            var categoryList = _serviceCS.GetCategorySubList(product.CategorySub.CategoryID);
            ViewBag.CategorySubID = categoryList.ToSelectList(v => v.CategorySubID, n => n.CategoryNameSub, product.CategorySubID);

            return PartialView(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [Route("Edit/{ProductID}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductModel,ProductName,CategorySubID,UnitPrice,Photo,Description,Status,CreateDate,ModifyDate")] ProductViewModel product, HttpPostedFileBase Photo)
        {
            if (ModelState.IsValid)
            {
                //檔案上傳
                if (Photo != null)
                {
                    Photo.SaveAs(Path.Combine(Server.MapPath(@"~/Content/ProductImages"),Photo.FileName));
                    //將檔案名稱放進 product.ProductImage (路徑名稱)
                    product.Photo = Photo.FileName;
                }
                else
                {

                }

                //建立時間
                product.ModifyDate = DateTime.Now;

                bool isSave = _serviceP.UpdateProduct(product);

                return Json(new { success = isSave });
            }

            int cateID = _serviceC.GetAllCateogryList().Where(c => c.CategoryID == product.CategorySubID).FirstOrDefault().CategoryID;
            var categoryList = _serviceCS.GetCategorySubList(cateID);
            ViewBag.CategorySubID = categoryList.ToSelectList(v => v.CategorySubID, n => n.CategoryNameSub, product.CategorySubID);

            return PartialView(product);
        }


        /// <summary>
        /// 取得圖片
        /// </summary>
        /// <param name="fileName">圖片名稱</param>
        /// <returns></returns>
        public ActionResult GetImagePath(string fileName)
        {
            return File("~/Content/ProductImages/" + fileName, "image/jpeg");
        }


        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var product = _serviceP.GetProductByID((int)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bool isSave = _serviceP.DeleteProduct(id);
            return RedirectToAction("Index");
        }


    }
}
