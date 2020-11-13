using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers {
    public class CategoryController : Controller {
        public InventoryContext db { get; set; }

        public CategoryController() {
            db = new InventoryContext();
        }

        public IActionResult Categories() {
            var categories = db.Categories.ToList();
            return View(categories);
        }
        
        public IActionResult Create() {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(CategoryModel model) {
            if (ModelState.IsValid) {
                model.date = DateTime.Now;
                db.Categories.Add(model);
                db.SaveChanges();
                ViewBag.message = "¡Registro guardado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "warning";
            }

            var categories = db.Categories.ToList();
            return View("Categories", categories);
        }

        public IActionResult Update(int id) {
            var category = db.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(CategoryModel model) {
            if (ModelState.IsValid) {
                var category = db.Categories.Find(model.id);
                category.description = model.description;
                category.date = DateTime.Now;
                category.idUser = 1;

                db.Categories.Update(category);
                db.SaveChanges();
                ViewBag.message = "¡Registro actualizado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "Los datos ingresados no son validos.";
                ViewBag.messageType = "warning";
            }

            var categories = db.Categories.ToList();
            return View("Categories", categories);
        }

        public IActionResult Delete(int id) {
            var category = db.Categories.Find(id);

            db.Categories.Remove(category);
            db.SaveChanges();

            var categories = db.Categories.ToList();
            return View("Categories", categories);
        }
    }
}