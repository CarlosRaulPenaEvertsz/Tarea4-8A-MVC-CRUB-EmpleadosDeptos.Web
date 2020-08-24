using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUB_EmpleadosDeptos.Models.Models;

namespace MVC_CRUB_EmpleadosDeptos.Web.Controllers
{
    public class DepartamentosController : Controller
    {
        private EmpleadoDBEntities db = new EmpleadoDBEntities();

        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.TBL_DEPARTAMENTO.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Nombre")] TBL_DEPARTAMENTO tBL_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TBL_DEPARTAMENTO.Add(tBL_DEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_DEPARTAMENTO);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // POST: Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Nombre")] TBL_DEPARTAMENTO tBL_DEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_DEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_DEPARTAMENTO);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            if (tBL_DEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBL_DEPARTAMENTO);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_DEPARTAMENTO tBL_DEPARTAMENTO = db.TBL_DEPARTAMENTO.Find(id);
            db.TBL_DEPARTAMENTO.Remove(tBL_DEPARTAMENTO);
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
