using ASPdotNetMVCframework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPdotNetMVCframework.Controllers
{
    public class ProductController : Controller
    {
        ProductEntities dbObj = new ProductEntities();
        // GET: Product
        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductTable myModel)
        {
            ProductTable dbTableobj = new ProductTable();
            dbTableobj.productName = myModel.productName;
            dbTableobj.productPrice = myModel.productPrice;
            dbObj.ProductTables.Add(dbTableobj);
            dbObj.SaveChanges();
            ModelState.Clear();
            return View("Product");
        }

        public ActionResult ProductList()
        {
            var res = dbObj.ProductTables.ToList();
            return View(res);
        }

        
        public ActionResult deleteProduct(int projectId)
        {
            var rest = dbObj.ProductTables.Where(x=>x.productId == projectId).First();
            dbObj.ProductTables.Remove(rest);
            dbObj.SaveChanges();

            var listres = dbObj.ProductTables.ToList();
            return View("ProductList", listres);
        }

        
        public ActionResult updateProduct(ProductTable objTbl)
        {
            if(objTbl != null)
            {
                return View(objTbl);
            }
            else
            {
                return View();
            }
        }
    }
}