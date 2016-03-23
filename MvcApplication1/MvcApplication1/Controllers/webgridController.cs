using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DB;

namespace MvcApplication1.Controllers
{
    public class webgridController : Controller
    {
        //
        // GET: /webgrid/

        public ActionResult Index()
        {
            using (demo_dbEntities db = new demo_dbEntities())
            {
                var list = db.Tax_Enter.ToList();
                return View(list);
            }
        }

        public ActionResult edt(int id, string Tax_name)
        {
            //string studentId = Request.QueryString["ID"].ToString();
            return View();
           
        }


        [OutputCache(Duration=0)]
       [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult show()
        {
            demo_dbEntities db = new demo_dbEntities();
            List<Tax_Enter> Emp = db.Tax_Enter.ToList();

            return Json(Emp, JsonRequestBehavior.AllowGet);
        }

    }


     

    public class EmpModel
    {
        public string Id { get; set; }
        public string Tax_name { get; set; }
        public int Tax_Percentage { get; set; }
        public string gender { get; set; }
        public int date { get; set; }
        
    }
}
