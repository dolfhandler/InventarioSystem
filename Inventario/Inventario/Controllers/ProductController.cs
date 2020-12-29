using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers {
    public class ProductController : Controller {
        public InventoryContext db { get; set; }

        public int USER = 1;

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
            model.user = USER;
            model.description = HttpUtility.HtmlEncode(model.description);
            model.photo = GetByteArrayFromFile(photo);
            if (ModelState.IsValid) {
                db.Products.Add(model);
                db.SaveChanges();

                SaveProductInInventory(model.id);

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

        private void SaveProductInInventory(int idProduct) {
            var model = new InventoryModel {
                inputs = 0,
                outputs = 0,
                stock = 0,
                product = idProduct,
                date = DateTime.Now,
                user = USER
            };
            db.Inventory.Add(model);
            db.SaveChanges();
        }

        public IActionResult Update(int id) {
            var product = db.Products.Find(id);
            LoadCategories();
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(ProductModel model, IFormFile photo) {
            if (ModelState.IsValid) {
                var product = db.Products.Find(model.id);
                #region UPDATE DATA
                product.photo = GetByteArrayFromFile(photo);
                product.category = model.category;
                product.code = model.code;
                product.date = DateTime.Now;
                product.description = HttpUtility.HtmlDecode(model.description);
                product.purchasePrice = model.purchasePrice;
                product.salePrice = model.salePrice;
                product.user = 1;
                #endregion

                db.Products.Update(product);
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

        public IActionResult Delete(int id) {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            ViewBag.message = "¡Registro eliminado satisfactoriamente!";
            ViewBag.messageType = "success";

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
                if(target.Length>0) {
                    file.CopyTo(target);
                    return target.ToArray();
                } else {
                    return new byte[1];
                }
            }
        }

    }
}