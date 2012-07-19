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

        // GET: /Debtors/
        public ActionResult Index()
        {
            var domainDebtors = _debtorRepository.FindAll();
            var modelDebtors = Mapper.Map<Debtor[], DebtorViewModel[]>(domainDebtors);

            return View(modelDebtors);
        }

        // GET: /Debtors/Details/5
        public ActionResult Details(int id)
        {
            var domainDebtor = _debtorRepository.FindById(id);

            if (domainDebtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            var modelDebtor = Mapper.Map<Debtor, DebtorViewModel>(domainDebtor);

            return View(modelDebtor);
        }

        // GET: /Debtors/Create
        public ActionResult Create()
        {
            var editModelDebtor = new DebtorEditModel { Debts = new DebtEditModel[4]};
            ViewBag.Title = "Create a new debtor";
            return View("CreateOrEdit", editModelDebtor);
        }

        // POST: /Debtors/Create
        [HttpPost]
        public ActionResult Create(DebtorEditModel editModelDebtor)
        {
            if (ModelState.IsValid)
            {
                var domainDebtor = new Debtor(editModelDebtor.Id);
                Mapper.Map(editModelDebtor, domainDebtor);
                _debtorRepository.MakePersistent(domainDebtor);
                return RedirectToAction("Index");
            }

            return View("CreateOrEdit", editModelDebtor);
        }

        // GET: /Debtors/Edit/5
        public ActionResult Edit(int id)
        {
            var domainDebtor = _debtorRepository.FindById(id);

            if (domainDebtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            var editModelDebtor = Mapper.Map<Debtor, DebtorEditModel>(domainDebtor);
            ViewBag.Title = string.Format("Edit {0}", editModelDebtor.Name);
            return View("CreateOrEdit", editModelDebtor);
        }

        // POST: /Debtors/Edit/5
        [HttpPost]
        public ActionResult Edit(DebtorEditModel editModelDebtor)
        {
            if (ModelState.IsValid) {
                var domainDebtor = new Debtor(editModelDebtor.Id);
                Mapper.Map(editModelDebtor, domainDebtor);
                _debtorRepository.MakePersistent(domainDebtor);
                return RedirectToAction("Index");
            }

            return View("CreateOrEdit", editModelDebtor);
        }

        // GET: /Debtors/Delete/5
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var domainDebtor = _debtorRepository.FindById(id);

            if (domainDebtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            var modelDebtor = Mapper.Map<Debtor, DebtorViewModel>(domainDebtor);

            return View(modelDebtor);
        }

        // POST: /Debtors/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try {
                var domainDebtor = _debtorRepository.FindById(id);

                if (domainDebtor == null) {
                    throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
                }

                _debtorRepository.MakeTransient(domainDebtor);

                return RedirectToAction("Index");
            }
            catch {
                // Is this the right thing to do ?
                // How do we convey the error ?
                return View();
            }
        }
    }
}
