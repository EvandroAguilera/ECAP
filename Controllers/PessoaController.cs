using ECAP.DAO;
using ECAP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAP.Controllers
{
    public class PessoaController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string nome)
        {
            try
            {
                List<Pessoa> pessoas = new List<Pessoa>();

                pessoas = db.Pessoa.Include(x => x.Departamento).OrderByDescending(x => x.idDepartamento).ToList();

                if (nome != "")
                {
                    pessoas = db.Pessoa.Where(x => x.Nome.Contains(nome)).ToList();
                }

                return View(pessoas);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
        }

        public ActionResult Create()
        {
            DepartamentoDropDownList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa model)
        {
            try
            {
                if (model.Nome == null)
                    ModelState.AddModelError("Nome", "Informe nome.");

                if (ModelState.IsValid)
                {
                    db.Pessoa.Add(model);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                DepartamentoDropDownList(model);
                return View(model);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
        }

        public ActionResult Editar(int? idPessoa)
        {
            try
            {
                Pessoa pessoa = db.Pessoa.Find(idPessoa);
                DepartamentoDropDownList(pessoa);
                return View(pessoa);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Pessoa model)
        {
            try
            {
                if (model.Nome == null)
                    ModelState.AddModelError("Nome", "Informe nome.");


                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
        }

        private void DepartamentoDropDownList(object selectedDepartment = null)
        {
            try
            {
                var query = db.Departamento.OrderByDescending(x => x.idDepartamento).ToList();

                ViewBag.idDepartamento = new SelectList(query, "idDepartamento", "Nome", selectedDepartment);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

        }
    }
}