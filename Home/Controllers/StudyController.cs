using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Home.Controllers
{
    public class StudyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AngularJs1()
        {
            return View();
        }
        public ActionResult AngularJs2()
        {
            return View();
        }
        public ActionResult AngularJs3()
        {
            return View();
        }
        public ActionResult AngularJs4()
        {
            return View();
        }
        public ActionResult AngularJs5()
        {
            return View();
        }
        public ActionResult AngularJs6()
        {
            return View();
        }
        public ActionResult AngularJs7()
        {
            return View();
        }
        public JsonResult ProductOrders()
        {
            return new JsonResult();
        }
        
        public JsonResult ProductResource(int id=0)
        {
            return Json(new Product(id, "Product #1", "A product", "Category #1", 100), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProductJsonResult()
        {
            try
            {
                var list = new List<Product>();
                list.Add(new Product(1, "Product #1", "A product", "Category #1", 100));
                list.Add(new Product(2, "Product #2", "A product", "Category #1", 110));
                list.Add(new Product(3, "Product #3", "A product", "Category #2", 210));
                list.Add(new Product(4, "Product #4", "A product", "Category #3", 202));

                return Json(new { result = "success", products = list }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { result = "fail", message = e.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        private class ProductJson
        {
            public IList<Product> products { get; set; }
        }
        private class Product
        {
            public Product(int i, string a, string b, string c, int d)
            {
                id = i;
                name = a;
                description = b;
                category = c;
                price = d;
            }
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string category { get; set; }
            public int price { get; set; }
        }

        public JsonResult TodoJsonDelay()
        {
            for (int i = 0; i < 100000000; i++)
            {

                Console.Write("test");

            }
            return TodoJson();
        }

        public JsonResult TodoJson()
        {
            var list = new List<ActionDone>();
            list.Add(new ActionDone("출근", false));
            list.Add(new ActionDone("조회", false));
            list.Add(new ActionDone("스터디", true));
            list.Add(new ActionDone("퇴근", false));

            var todo = new Todo();
            todo.user = "동하";
            todo.items = list;

            return Json(todo);
        }

        private class Todo
        {
            public string user { get; set; }
            public IList<ActionDone> items { get; set; }
        }
        private class ActionDone
        {
            public ActionDone(string a, bool d)
            {
                action = a;
                done = d;
            }
            public string action { get; set; }
            public bool done { get; set; }
        }
    }
}
