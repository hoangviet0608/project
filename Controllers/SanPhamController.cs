using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH.Controllers
{
    public class SanPhamController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext("Data Source=DESKTOP-0746MOR;Initial Catalog=qlbh1;Integrated Security=True;TrustServerCertificate=True");
        // GET: SanPham

        public ActionResult Add()
        {
            return View();
        }

        public string Create(FormCollection form)
        {
            //code xu ly add
            string id = form["ID"];
            string name = form["Name"];

            sanpham newObj = new sanpham();
            newObj.id = id;
            newObj.name = name;

            db.sanphams.InsertOnSubmit(newObj);
            db.SubmitChanges();

            return "them moi thanh cong";
        }

        public ActionResult Edit()
        {
            string abc = Request.QueryString["id"];
            sanpham editObj = db.sanphams.Where(o => o.id == abc).FirstOrDefault();
            return View(editObj);
        }

        public string PostEdit(FormCollection form)
        {
            string id = form["ID"];
            string name = form["Name"];

            sanpham editObj = db.sanphams.Where(o => o.id == id).FirstOrDefault();

            editObj.name = name;

            db.SubmitChanges();

            return "chinh sua thanh cong";
        }

        public ActionResult Delete()
        {
            string id = Request.QueryString["id"];
            sanpham delObj = db.sanphams.Where(o => o.id == id).FirstOrDefault();
            if(delObj == null)
            {
                return View("index", db.sanphams.ToList());
            }

            db.sanphams.DeleteOnSubmit(delObj);
            db.SubmitChanges();

            var x = db.sanphams.ToList();
            return View("index", x);
        }
        public ActionResult Index()
        {
            var x = db.sanphams.ToList();
            return View(x);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nguyen Hoang Viet";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nguyen Hoang Viet";

            return View();
        }
    }
}