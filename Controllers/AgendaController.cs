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
    public class AgendaController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string nome)
        {
            try
            {
                List<Agenda> agendas = new List<Agenda>();

                agendas = db.Agenda.OrderByDescending(x => x.idAgenda).ToList();

                if (nome != "")
                {
                    agendas = db.Agenda.Where(x => x.Nome.Contains(nome)).ToList();
                }

                return View(agendas);
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
        public ActionResult Create(Agenda model)
        {
            try
            {
                if (model.Nome == null)
                    ModelState.AddModelError("Nome", "Informe nome.");
                if (model.Telefone == null)
                    ModelState.AddModelError("Telefone", "Informe Telefone.");
                if (model.Endereco == null)
                    ModelState.AddModelError("Endereco", "Informe Endereco.");
                if (ModelState.IsValid)
                {
                    db.Agenda.Add(model);
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

        public ActionResult Editar(int? idAgenda)
        {
            try
            {
                Agenda agenda = db.Agenda.Find(idAgenda);

                return View(agenda);
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
        public ActionResult Editar(Agenda model)
        {
            try
            {
                if (model.Nome == null)
                    ModelState.AddModelError("Nome", "Informe nome.");
                if (model.Telefone == null)
                    ModelState.AddModelError("Telefone", "Informe Telefone.");
                if (model.Endereco == null)
                    ModelState.AddModelError("Endereco", "Informe Endereco.");

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


        public ActionResult Excluir(int? idAgenda)
        {
            try
            {
               
                Agenda agenda = db.Agenda.Find(idAgenda);

                return View(agenda);
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
        public ActionResult Excluir(Agenda model)
        {
            try
            {
                Agenda agenda = db.Agenda.Find(model.idAgenda);
                db.Agenda.Remove(agenda);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Excluir", new { idGrupo = model.idAgenda});
            }
            finally
            {
                db.Dispose();

            }
        }
    }
}