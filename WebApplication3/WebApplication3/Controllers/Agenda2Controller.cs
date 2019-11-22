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
    public class Agenda2Controller : Controller
    {
        private Model53Container db = new Model53Container();

        // GET: Agenda2
        public ActionResult Index()
        {
            return View(db.Agenda2Set.ToList());
        }

        // GET: Agenda2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda2 agenda2 = db.Agenda2Set.Find(id);
            if (agenda2 == null)
            {
                return HttpNotFound();
            }
            return View(agenda2);
        }

        // GET: Agenda2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agenda2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Evento,Fecha,Hora")] Agenda2 agenda2)
        {
            if (ModelState.IsValid)
            {
                db.Agenda2Set.Add(agenda2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agenda2);
        }

        // GET: Agenda2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda2 agenda2 = db.Agenda2Set.Find(id);
            if (agenda2 == null)
            {
                return HttpNotFound();
            }
            return View(agenda2);
        }

        // POST: Agenda2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evento,Fecha,Hora")] Agenda2 agenda2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agenda2);
        }

        // GET: Agenda2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda2 agenda2 = db.Agenda2Set.Find(id);
            if (agenda2 == null)
            {
                return HttpNotFound();
            }
            return View(agenda2);
        }

        // POST: Agenda2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda2 agenda2 = db.Agenda2Set.Find(id);
            db.Agenda2Set.Remove(agenda2);
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
