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
    public class DebtManagementPlanController : Controller
    {
        private readonly IDebtorRepository _debtorRepository;

        public DebtManagementPlanController(IDebtorRepository debtorRepository)
        {
            _debtorRepository = debtorRepository;
        }

        public ActionResult Details(int id, Company? company)
        {
            var debtor = _debtorRepository.FindById(id);

            if (debtor == null) {
                throw new InvalidOperationException(string.Format("Temporary exception - no debtor found with id \"{0}\".", id));
            }

            var dmp = (company.HasValue) ? new DebtManagementPlan(debtor, company.Value) : new DebtManagementPlan(debtor);
            var model = Mapper.Map<DebtManagementPlan, DebtManagementPlanViewModel>(dmp);

            return View(model);
        }
    }
}
