using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.DB;
using MvcApplication1.Models;
using System.Data;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace MvcApplication1.Controllers
{
    public class homeController : Controller
    {
        
        //
        // GET: /home/

        public ActionResult Index()
        {
            
                
                return View();
            
        }

        [OutputCache(Duration = 0)]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult show()
        {
            demo_dbEntities db = new demo_dbEntities();
           // List<Tax_Enter> Emp = db.Tax_Enter.ToList();
            List<Tax_Enter> Emp = db.Tax_Enter.ToList(); 
            return Json(Emp, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 0)]
        [AcceptVerbs(HttpVerbs.Post)]
        public string Edit(int Id, string Tax_name, string Tax_Percentage, string gender, string date)
        {
            demo_dbEntities db = new demo_dbEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                   // Tax_Enter Emp = new Tax_Enter();
                    Tax_Enter Emp = db.Tax_Enter.First(em1 => em1.Id == Id);
                    Emp.Tax_name = Tax_name;
                    Emp.Tax_Percentage = Tax_Percentage;
                    Emp.gender = gender;
                    Emp.date = date;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
    [OutputCache(Duration=0)]
        [HttpPost]
        public string Create(int Id, string Tax_name, string Tax_Percentage, string gender, string date)
        {

            demo_dbEntities db = new demo_dbEntities();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    Tax_Enter Emp = new Tax_Enter();
                    Emp.Id=Id;
                    Emp.Tax_name = Tax_name;
                    Emp.Tax_Percentage = Tax_Percentage;
                    Emp.gender = gender;
                    Emp.date = date;
                    db.AddToTax_Enter(Emp);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }


        public string Delete(int Id)
        {
            demo_dbEntities db = new demo_dbEntities();
        Tax_Enter Emp = db.Tax_Enter.First(em1 => em1.Id == Id);
            db.DeleteObject(Emp);
            db.SaveChanges();
            return "Deleted successfully";
        }

    }
}
