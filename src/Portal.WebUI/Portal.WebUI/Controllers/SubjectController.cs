using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.Model.SubjectModels;
using Portal.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.WebUI.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectservice;
        public SubjectController(ISubjectService subjectservice)
        {
            _subjectservice = subjectservice;
        }
        // GET: SubjectController
        public ActionResult Index()
        {
            var list = _subjectservice.GetAllSubjects();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectModel model)
        {
            try
            {
                _subjectservice.CreateSubjectModel(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
