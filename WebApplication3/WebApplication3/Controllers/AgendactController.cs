using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AgendactController : Controller
    {
        private Model7Container db = new Model7Container();

        // GET: Agendact
        public ActionResult Index()
        {

            return View(db.Agenda1Set.ToList());
        }

        // GET: Agendact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda1 agenda1 = db.Agenda1Set.Find(id);
            if (agenda1 == null)
            {
                return HttpNotFound();
            }
            return View(agenda1);
        }

        // GET: Agendact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agendact/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cedula,Email,Direccion")] Agenda1 agenda1)
        {
            if (ModelState.IsValid)
            {
                db.Agenda1Set.Add(agenda1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agenda1);
        }

        // GET: Agendact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda1 agenda1 = db.Agenda1Set.Find(id);
            if (agenda1 == null)
            {
                return HttpNotFound();
            }
            return View(agenda1);
        }

        // POST: Agendact/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Cedula,Email,Direccion")] Agenda1 agenda1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agenda1);
        }

        // GET: Agendact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda1 agenda1 = db.Agenda1Set.Find(id);
            if (agenda1 == null)
            {
                return HttpNotFound();
            }
            return View(agenda1);
        }

        // POST: Agendact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda1 agenda1 = db.Agenda1Set.Find(id);
            db.Agenda1Set.Remove(agenda1);
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
