using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class ClientController : Controller
    {
        public InventoryContext db { get; set; }

        public ClientController() {
            db = new InventoryContext();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TerceroModel tercero)
        {
            db.Terceros.Add(tercero);
            return View();
        }
    }
}