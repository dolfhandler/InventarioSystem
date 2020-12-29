using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Context;
using Inventario.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class ProviderController : Controller
    {
        public InventoryContext db {
            get; set;
        }

        public int USER = 1;
        public dynamic model = new ExpandoObject();
        public ProviderController() {
            db = new InventoryContext();
        }

        private void LoadModel() {
            model.providers = db.Providers.ToList();
            model.phones = db.TelefonosTercero.ToList();
            model.terceros = db.Terceros.ToList();
        }

        public IActionResult Providers()
        {
            LoadModel();
            return View(model);
        }

        public IActionResult Create() {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(TerceroModel tercero, List<string> phoneCollection, string web_page) {
            if (ModelState.IsValid) {
                int id_tercero = SaveTercero(tercero);
                SaveProvider(id_tercero, web_page);
                SavePhoneTercero(id_tercero, phoneCollection);
                db.SaveChanges();
                ViewBag.message = "Registro guardado satisfactoriamente.";
                ViewBag.messageType = "success";
            } else {
                ViewBag.message = "El registro no pudo ser guardado.";
                ViewBag.messageType = "danger";
                return View();
            }
            LoadModel();
            return View("Providers", model);
        }

        private void SaveProvider(int id_ter, string page) {
            try {
                var provider = new ProviderModel {
                    id = 0,
                    date = DateTime.Now,
                    id_tercero = id_ter,
                    user = USER,
                    web_page = page
                };
                db.Providers.Add(provider);

            }catch (Exception e) {

            }
        }

        private void SavePhoneTercero(int id_tercero, List<string> phoneCollection) {
            try {
                foreach(var phoneJSON in phoneCollection) {
                    var phone = JsonConvert.DeserializeObject<TerceroPorTelefonoModel>(phoneJSON);
                    phone.client = id_tercero;
                    db.TelefonosTercero.Add(phone);
                }
            }catch  (Exception e) {

            }
        }

        private int SaveTercero(TerceroModel tercero) {
            tercero.date = DateTime.Now;
            tercero.user = USER;
            db.Terceros.Add(tercero);
            db.SaveChanges();
            return tercero.id;
        }
    }
}