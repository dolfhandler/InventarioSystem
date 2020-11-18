using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers {
    public class TypeSaleController : Controller {
        public InventoryContext db { get; set; }

        public TypeSaleController() {
            db = new InventoryContext();
        }

        public IActionResult TypeSales() {
            var type = db.TypeSales.ToList();
            return View(type);
        }
        
        public IActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(TypeSaleModel model) {
            if (ModelState.IsValid) {
                model.date = DateTime.Now;
                model.description = HttpUtility.HtmlEncode(model.description);
                model.idUser = 1;
                db.TypeSales.Add(model);
                db.SaveChanges();
                ViewBag.message = "¡Registro guardado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "warning";
            }

            var types = db.TypeSales.ToList();
            return View("TypeSales", types);
        }

        public IActionResult Update(int id) {
            var type = db.TypeSales.Find(id);
            return View(type);
        }

        [HttpPost]
        public IActionResult Update(TypeSaleModel model) {
            if (ModelState.IsValid) {
                var type = db.TypeSales.Find(model.id);
                type.description = HttpUtility.HtmlEncode(model.description);
                type.date = DateTime.Now;
                type.idUser = 1;

                db.TypeSales.Update(type);
                db.SaveChanges();
                ViewBag.message = "¡Registro actualizado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "Los datos ingresados no son validos.";
                ViewBag.messageType = "warning";
            }

            var types = db.TypeSales.ToList();
            return View("TypeSales", types);
        }

        public IActionResult Delete(int id) {
            var type = db.TypeSales.Find(id);

            db.TypeSales.Remove(type);
            db.SaveChanges();

            var types = db.TypeSales.ToList();
            return View("TypeSales", types);
        }
    }
}