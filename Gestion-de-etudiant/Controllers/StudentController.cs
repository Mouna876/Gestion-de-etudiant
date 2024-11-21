using Gestion_de_etudiant.Models;
using Gestion_de_etudiant.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_de_etudiant.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class StudentController : Controller
    {
        readonly IStudentRepository StudentRepository;
        readonly ISchoolRepository schoolrepository;


        public StudentController(IStudentRepository StudRepository, ISchoolRepository schRepository)
        {
            schoolrepository = schRepository;
            StudentRepository = StudRepository;
        }
        // GET: StudentController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var Studiants = StudentRepository.GetAll();

            return View(Studiants);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var Studiants = StudentRepository.GetById(id);

            return View(Studiants);
        }

        // GET: StudentController/Create
        public ActionResult Create(int id)
        {
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(),"SchoolID","SchoolName");
            return View();
        }


        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Student newStudent)
        {
            try
            {
                StudentRepository.Add(newStudent);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var student = StudentRepository.GetById(id);
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, Student newStudent)
        {
            try
            {
                StudentRepository.Edit(newStudent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var student = StudentRepository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Student student)
        {
            try
            {
                StudentRepository.Delete(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string name, int? schoolid)

        {
            var result = StudentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = StudentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = StudentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(schoolrepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }
    }
}
