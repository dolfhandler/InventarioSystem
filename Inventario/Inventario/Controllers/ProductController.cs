using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers {
    public class ProductController : Controller {
        public InventoryContext db { get; set; }

        public ProductController() {
            db = new InventoryContext();
        }

        public IActionResult Products() {
            var products = db.Products.ToList();
            LoadCategories();
            return View(products);
        }

        public IActionResult Create() {
            LoadCategories();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model, IFormFile photo) {
            model.date = DateTime.Now;
            model.user = 1;
            model.photo = GetByteArrayFromFile(photo);
            if (ModelState.IsValid) {
                db.Products.Add(model);
                db.SaveChanges();
                ViewBag.message = "¡Registro guardado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "warning";
            }

            var products = db.Products.ToList();
            LoadCategories();
            return View("Products", products);
        }

        private void LoadCategories() {
            var categories = db.Categories.ToList();
            ViewBag.categories = categories;
        }

        private byte[] GetByteArrayFromFile(IFormFile file) {
            using (var target = new MemoryStream()) {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

    }
}