using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finally2.Models;

namespace Finally2.Controllers
{
    public class EventosAController : Controller
    {
        private AgendaEntities db = new AgendaEntities();

        // GET: EventosA
        public ActionResult Index(string busqueda)
        {
            var lista = from x in db.EventosA
                        select x;

            if (String.IsNullOrEmpty(busqueda))
            {

                return View(db.EventosA.ToList());
            }
            else
            {
                lista = lista.Where(a => a.Eventos.Contains(busqueda));

                return View(lista);
            }
        }

        // GET: EventosA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventosA eventosA = db.EventosA.Find(id);
            if (eventosA == null)
            {
                return HttpNotFound();
            }
            return View(eventosA);
        }

        // GET: EventosA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventosA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Eventos,Fecha,Hora")] EventosA eventosA)
        {
            if (ModelState.IsValid)
            {
                db.EventosA.Add(eventosA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventosA);
        }

        // GET: EventosA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventosA eventosA = db.EventosA.Find(id);
            if (eventosA == null)
            {
                return HttpNotFound();
            }
            return View(eventosA);
        }

        // POST: EventosA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Eventos,Fecha,Hora")] EventosA eventosA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventosA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventosA);
        }

        // GET: EventosA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventosA eventosA = db.EventosA.Find(id);
            if (eventosA == null)
            {
                return HttpNotFound();
            }
            return View(eventosA);
        }

        // POST: EventosA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventosA eventosA = db.EventosA.Find(id);
            db.EventosA.Remove(eventosA);
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
