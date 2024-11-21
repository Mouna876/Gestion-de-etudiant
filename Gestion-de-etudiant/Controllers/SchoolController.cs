using Gestion_de_etudiant.Models;
using Gestion_de_etudiant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_de_etudiant.Controllers
{

    [Authorize(Roles = "Admin,Manager")]
    public class SchoolController : Controller
    {
        readonly ISchoolRepository schoolrepository;
        public SchoolController(ISchoolRepository ScoRepository)
        {

            schoolrepository = ScoRepository;
        }
        [AllowAnonymous]
        // GET: SchoolController
        public ActionResult Index()
        {
            var Schools = schoolrepository.GetAll();

            return View(Schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var Schools = schoolrepository.GetById(id);

            return View(Schools);
        }

        // GET: SchoolController/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, School school)
        {
            try
            {
                schoolrepository.Add(school);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var school = schoolrepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, School school)
        {
            try
            {
                schoolrepository.Edit(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var school = schoolrepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, School school)
        {
            try
            {
                schoolrepository.Delete(school);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
