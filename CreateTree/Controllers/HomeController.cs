using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateTree.Models;
using System.Data.Entity;
namespace CreateTree.Controllers
{
    public class HomeController : Controller
    {
        NodeDatabaseEntities db = new NodeDatabaseEntities();
        // GET: Home
        public ActionResult Index()
        {
            var inde = db.Parents.ToList();
            return View(inde);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Parent c)
        {
            db.Parents.Add(c);
            var creat = db.SaveChanges();
            if(creat>0)
            {
                TempData["insertmsg"] = "<script>alert('Record Inserted....!!!')</script>";
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["notinsrtmsg"] = "<script>alert('Not RecordInserted...!!!')</script>";
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var ed = db.Parents.Where(model => model.nodeId == id).FirstOrDefault();

            return View(ed);
        }
        [HttpPost]
        public ActionResult Edit(Parent edit)
        {
            if(ModelState.IsValid==true)
            {
                db.Entry(edit).State = EntityState.Modified;
                var edi = db.SaveChanges();
                if (edi > 0)
                {
                    TempData["editmsg"] = "<script>alert('Upated Record...!!!')</script>";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["noteditmsg"] = "<script>alert('Not Updated Record..!!!')</script>";
                }
            }
            
            return View();
        }
        
        public ActionResult Delete(int id)
        {
            if(ModelState.IsValid==true)
            {
                var del = db.Parents.Where(model => model.nodeId == id).FirstOrDefault();
                if(del!=null)
                {
                    db.Entry(del).State = EntityState.Deleted;
                    var d = db.SaveChanges();
                    if(d>0)
                    {
                        TempData["delmsg"] = "<script>alert('Delete Record...!!!')</script>";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["notdelmsg"] = "<script>alert('Not Delete Record...!!!!')</script>";
                    }
                }
                    
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var deta = db.Parents.Where(model => model.nodeId == id).FirstOrDefault();
            return View(deta);
        }
    }
}