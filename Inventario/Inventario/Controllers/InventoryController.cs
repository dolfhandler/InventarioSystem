using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers {
    public class InventoryController : Controller {
        public InventoryContext db { get; set; }

        public InventoryController() {
            db = new InventoryContext();
        }

        public IActionResult Inventory() {
            var stock = db.Inventory.ToList();
            var products = db.Products.ToList();

            var productsInStock = from a in stock
                                  join b in products on a.product equals b.id // into ab
                                  // from subAB in ab.DefaultIfEmpty()
                                  select new InventoryModel {
                                      id = a.id,
                                      product = b.id,
                                      productName = b.description,
                                      inputs = a.inputs,
                                      outputs = a.outputs,
                                      stock = a.stock
                                  };
            return View(productsInStock);
        }
        
        [HttpPost]
        public IActionResult Input(InventoryModel model) {
            model.date = DateTime.Now;
            model.user = 1;
            model.outputs = 0;
            if (ModelState.IsValid) {
                db.Inventory.Add(model);
                db.SaveChanges();
                ViewBag.message = "¡Registro guardado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "warning";
            }

            var stock = db.Inventory.ToList();
            return View("Inventory", stock);
        }

        public IActionResult Update(int id) {
            var stock = db.Inventory.Find(id);
            return View(stock);
        }

        public IActionResult Delete(int id) {
            var product = db.Inventory.Find(id);
            db.Inventory.Remove(product);
            db.SaveChanges();

            ViewBag.message = "¡Registro eliminado satisfactoriamente!";
            ViewBag.messageType = "success";

            var stock = db.Inventory.ToList();
            return View("Inventory", stock);
        }

    }
}