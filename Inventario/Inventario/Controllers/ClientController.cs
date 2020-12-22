using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Inventario.Controllers {
    public class ClientController : Controller {
        public InventoryContext db { get; set; }

        public int USER = 1;

        public dynamic model = new ExpandoObject();

        public ClientController() {
            db = new InventoryContext();
        }

        public IActionResult Clients() {
            LoadModel();
            return View(model);
        }

        private void LoadModel() {
            model.clients = db.Clients.ToList();
            model.phones = db.TelefonosTercero.ToList();
            model.terceros = db.Terceros.ToList();
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TerceroModel tercero, List<string> phoneCollection) {
            if (ModelState.IsValid) {
                var idTercero = SaveTercero(tercero);
                SaveClient(idTercero);
                SaveTelefonosPorTercero(idTercero, phoneCollection);
                db.SaveChanges();
                ViewBag.message = "Registro guardado satisfactoriamente.";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "danger";
                return View();
            }
            LoadModel();
            return View("Clients", model);
        }

        private int SaveTercero(TerceroModel tercero) {
            tercero.date = DateTime.Now;
            tercero.user = USER;
            db.Terceros.Add(tercero);
            db.SaveChanges();

            return tercero.id;
        }

        private void SaveClient(int idTercero) {
            try {
                var client = new ClientModel {
                    id = 0,
                    date = DateTime.Now,
                    tercero = idTercero,
                    user = USER
                };
                db.Clients.Add(client);
            } catch (Exception ex) {

            }
        }

        private void SaveTelefonosPorTercero(int idTercero, List<string> phoneCollection) {
            try {
                foreach (var phoneJSON in phoneCollection) {
                    var phone = JsonConvert.DeserializeObject<TerceroPorTelefonoModel>(phoneJSON);
                    phone.client = idTercero;
                    db.TelefonosTercero.Add(phone);
                }
            } catch (Exception ex) {

            }
        }

    }
}