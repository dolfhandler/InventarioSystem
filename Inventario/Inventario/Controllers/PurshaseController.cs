using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class PurshaseController : Controller
    {
        public InventoryContext db {
            get; set;
        }

        public int USER = 1;
        public dynamic model = new ExpandoObject();

        public PurshaseController() {
            db = new InventoryContext();
        }
        private void LoadModel() {
            model.purshises = db.Purshase.ToList();
            model.purshisesProducts = db.PurshasesProducts.ToList();
        }
        public IActionResult Purshases()
        {
            LoadModel();
            LoadInventario();
            LoadClient();
            LoadVoucher();
            return View(model);
        }
        private void LoadInventario() {
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
            ViewBag.productsInStock = productsInStock;
        }
        private void LoadClient() {
            var clients = db.Clients.ToList();
            var terceros = db.Terceros.ToList();

            var clientsall = from a in clients
                             join b in terceros on a.tercero equals b.id // into ab
                                                                         // from subAB in ab.DefaultIfEmpty()
                             select new ClientModel {
                                 id = a.id,
                                 tercero = b.id,
                                 name = b.firstName +" "+ b.middleName
                              };
            ViewBag.clientsall = clientsall;
        }

        private void LoadVoucher() {
            var vouchers = db.Vouchers.ToList();
            ViewBag.vouchers = vouchers;
        }
    }
}