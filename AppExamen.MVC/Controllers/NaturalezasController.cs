using AppExamen.CosumeAPI;
using AppExamen.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppExamen.MVC.Controllers
{
    public class NaturalezasController : Controller
    {
        private string urlApi;
        public NaturalezasController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Empleados";
            //this.urlBase = configuration.GetValue("ApiUrlBase", "").ToString();
        }

        // GET: NaturalezasController
        public ActionResult Index()
        {
            var data = Crud<Naturaleza>.Read(urlApi);
            return View();
        }

        // GET: NaturalezasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Naturaleza>.Read_ById(urlApi, id);
            return View();
        }

        // GET: NaturalezasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NaturalezasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Naturaleza data)
        {
            try
            {
                var newData = Crud<Naturaleza>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: NaturalezasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Naturaleza>.Read_ById(urlApi, id);
            return View();
        }

        // POST: NaturalezasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Naturaleza data)
        {
            try
            {
                Crud<Naturaleza>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: NaturalezasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Naturaleza>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: NaturalezasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Naturaleza data)
        {
            try
            {
                Crud<Naturaleza>.Delete(urlApi, id);
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
