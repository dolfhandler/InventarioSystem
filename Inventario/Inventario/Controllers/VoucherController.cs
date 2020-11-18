using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class VoucherController : Controller
    {
        public InventoryContext db { get; set; }

        public VoucherController() {
            db = new InventoryContext();
        }

        public IActionResult Vouchers() {
            var vouchers = db.Vouchers.ToList();
            return View(vouchers);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VoucherModel model) {
            if (ModelState.IsValid) {
                model.date = DateTime.Now;
                model.description = HttpUtility.HtmlEncode(model.description);
                model.idUser = 1;
                db.Vouchers.Add(model);
                db.SaveChanges();
                ViewBag.message = "¡Registro guardado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "warning";
            }

            var vouchers = db.Vouchers.ToList();
            return View("Vouchers", vouchers);
        }

        public IActionResult Update(int id) {
            var voucher = db.Vouchers.Find(id);
            return View(voucher);
        }

        [HttpPost]
        public IActionResult Update(VoucherModel model) {
            if (ModelState.IsValid) {
                var voucher = db.Vouchers.Find(model.id);
                voucher.description = HttpUtility.HtmlEncode(model.description);
                voucher.date = DateTime.Now;
                voucher.idUser = 1;

                db.Vouchers.Update(voucher);
                db.SaveChanges();
                ViewBag.message = "¡Registro actualizado satisfactoriamente!";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "Los datos ingresados no son validos.";
                ViewBag.messageType = "warning";
            }

            var vouchers = db.Vouchers.ToList();
            return View("Vouchers", vouchers);
        }

        public IActionResult Delete(int id) {
            var voucher = db.Vouchers.Find(id);

            db.Vouchers.Remove(voucher);
            db.SaveChanges();

            var vouchers = db.Vouchers.ToList();
            return View("Vouchers", vouchers);
        }
    }
}