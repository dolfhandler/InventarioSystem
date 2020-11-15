using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers {
    public class TypePayment : Controller {
        public InventoryContext db { get; set; }

        public TypePayment() {
            db = new InventoryContext();
        }

        public IActionResult TypePayments() {
            var types = db.TypePayments.ToList();
            return View(types);
        }
        
        public IActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(TypePaymentModel model) {
            if (ModelState.IsValid) {
                model.date = DateTime.Now;
                model.idUser = 1;
                db.TypePayments.Add(model);
                db.SaveChanges();
                ViewBag.message = "¡Registro guardado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "warning";
            }

            var types = db.TypePayments.ToList();
            return View("TypePayments", types);
        }

        public IActionResult Update(int id) {
            var types = db.TypePayments.Find(id);
            return View(types);
        }

        [HttpPost]
        public IActionResult Update(TypePaymentModel model) {
            if (ModelState.IsValid) {
                var type = db.TypePayments.Find(model.id);
                type.description = model.description;
                type.date = DateTime.Now;
                type.idUser = 1;

                db.TypePayments.Update(type);
                db.SaveChanges();
                ViewBag.message = "¡Registro actualizado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "Los datos ingresados no son validos.";
                ViewBag.messageType = "warning";
            }

            var types = db.TypePayments.ToList();
            return View("TypePayments", types);
        }

        public IActionResult Delete(int id) {
            var category = db.TypePayments.Find(id);

            db.TypePayments.Remove(category);
            db.SaveChanges();

            var types = db.TypePayments.ToList();
            return View("TypePayments", types);
        }
    }
}