using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCC.Models;

namespace TCC.Controllers
{
    public class CompanyController : Controller
    {
        /* Atributo que instancia da classe do banco */
        private ApplicationDbContext db;
    
        /* Construtor da classe que passa para o atributo AppDbContext a instância para o database */
        public CompanyController()
        {
            db = new ApplicationDbContext();
        }

        /* método para liberação de recursos */
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        /* Action da tela inicial */
        public ActionResult Index()
        {
            var companies = db.Companies.ToList();
            return View(companies);
        }

        public ActionResult Details(int id)
        {
            /* Retorna o único elemento de uma sequência ou um valor padrão se a sequência é vazia; esse método gera uma exceção se há mais de um elemento na sequência. */
            var companies = db.Companies.SingleOrDefault(c => c.Id == id);
            if (companies == null)
            {
                return HttpNotFound();
            }
            return View(companies);

        }

        public ActionResult New()
        {
            var company = new Company();
            return View("CompanyForm", company);
        }

        public ActionResult Save(Company company)
        {

            if (!ModelState.IsValid)
            {
                return View("CompanyForm", company);
            }

            if (company.Id == 0)
            {
                db.Companies.Add(company);
            }
            else
            {
                var companyInDb = db.Companies.Single(e => e.Id == company.Id);

                companyInDb.Name = company.Name;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {

            var company = db.Companies.SingleOrDefault(e => e.Id == id);

            if (company == null)
            {
                return HttpNotFound();
            }

            return View("CompanyForm", company);
        }

        public ActionResult Delete(int id)
        {
            var company = db.Companies.SingleOrDefault(c => c.Id == id);

            if (company == null)
                return HttpNotFound();

            db.Companies.Remove(company);
            db.SaveChanges();

            return new HttpStatusCodeResult(200);
        }

    }
}