using System;
using System.Web.UI;
using System.Web.Mvc;
using DebtMan.DomainModel;
using DebtMan.DomainModel.Repositories;
using DebtMan.WebApp.Models;
using AutoMapper;

namespace DebtMan.WebApp.Controllers
{
    [OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
    public class DebtorsController : Controller
    {
        private readonly IDebtorRepository _debtorRepository;

        public DebtorsController(IDebtorRepository debtorRepository)
        {
            _debtorRepository = debtorRepository;
        }

        //
        // GET: /Debtors/
        public ActionResult Index()
        {
            Debtor[] debtors = _debtorRepository.FindAll();
            DebtorModel[] model = Mapper.Map<Debtor[], DebtorModel[]>(debtors);

            return View(model);
        }

        //
        // GET: /Debtors/Details/5
        public ActionResult Details(int id)
        {
            Debtor debtor = _debtorRepository.FindById(id);

            if (debtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            DebtorModel model = Mapper.Map<Debtor, DebtorModel>(debtor);

            return View(model);
        }

        //
        // GET: /Debtors/Create
        public ActionResult Create()
        {
            Debtor model = new Debtor();

            model.Creditors = new Creditor[]
            {
                new Creditor() {}
            };

            return View(model);
        }

        //
        // POST: /Debtors/Create
        [HttpPost]
        public ActionResult Create(Debtor debtor)
        {
            try {
                _debtorRepository.MakePersistent(debtor);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Debtors/Edit/5
        public ActionResult Edit(int id)
        {
            Debtor debtor = _debtorRepository.FindById(id);

            if (debtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            DebtorModel model = Mapper.Map<Debtor, DebtorModel>(debtor);

            return View(model);
        }

        //
        // POST: /Debtors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        //
        // GET: /Debtors/Delete/5
        public ActionResult Delete(int id)
        {
            Debtor debtor = _debtorRepository.FindById(id);

            if (debtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            DebtorModel model = Mapper.Map<Debtor, DebtorModel>(debtor);

            return View(model);
        }

        //
        // POST: /Debtors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                Debtor debtor = _debtorRepository.FindById(id);

                if (debtor == null) {
                    throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
                }

                _debtorRepository.MakeTransient(debtor);

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public ActionResult AddCreditorEditorRow()
        {
            return PartialView("CreditorEditorRow", new Creditor());
        }
    }
}
