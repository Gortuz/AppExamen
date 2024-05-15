using AppExamen.CosumeAPI;
using AppExamen.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppExamen.MVC.Controllers
{
    public class PokemonesController : Controller
    {
        private string urlApi;
        private string urlBase;

        public PokemonesController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Pokemones";
            this.urlBase = configuration.GetValue("ApiUrlBase", "").ToString();
        }

        private Naturaleza[] ObtenerListaNaturalezas()
        {

            return Crud<Naturaleza>.Read(urlBase + "/Naturalezas");
        }

        // GET: PokemonesController
        public ActionResult Index()
        {

            var data = Crud<Pokemon>.Read(urlApi);
            return View(data);
        }

        // GET: PokemonesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Pokemon>.Read_ById(urlApi, id);
            return View();
        }

        // GET: PokemonesController/Create
        public ActionResult Create()
        {
            ViewBag.Naturalezas = ObtenerListaNaturalezas().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Nombre
            }).ToList();
            return View();
        }

        // POST: PokemonesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pokemon data)
        {
            try
            {
                var newData = Crud<Pokemon>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PokemonesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Naturalezas = ObtenerListaNaturalezas().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Nombre
            }).ToList();
            var data = Crud<Pokemon>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: PokemonesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pokemon data)
        {
            try
            {
                Crud<Pokemon>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: PokemonesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Pokemon>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: PokemonesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pokemon data)
        {
            try
            {
                Crud<Pokemon>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
