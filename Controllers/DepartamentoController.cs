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
    public class DepartamentoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string nome)
        {
            try
            {
                List<Departamento> departamentos = new List<Departamento>();

                departamentos = db.Departamento.OrderByDescending(x => x.idDepartamento).ToList();

                if (nome != "")
                {
                    departamentos = db.Departamento.Where(x => x.Nome.Contains(nome)).ToList();
                }

                return View(departamentos);
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departamento model)
        {
            try
            {
                if (model.Nome == null)
                    ModelState.AddModelError("Nome", "Informe nome.");
               
                if (ModelState.IsValid)
                {
                    db.Departamento.Add(model);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

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

        public ActionResult Editar(int? idDepartamento)
        {
            try
            {
                Departamento departamento = db.Departamento.Find(idDepartamento);

                return View(departamento);
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
        public ActionResult Editar(Departamento model)
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

        public ActionResult Excluir(int? idDepartamento)
        {
            try
            {

                Departamento departamento = db.Departamento.Find(idDepartamento);

                return View(departamento);
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
        public ActionResult Excluir(Departamento model)
        {
            try
            {
                Departamento departamento = db.Departamento.Find(model.idDepartamento);
                db.Departamento.Remove(departamento);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Excluir", new { idDepartamento = model.idDepartamento });
            }
            finally
            {
                db.Dispose();

            }
        }
    }
}