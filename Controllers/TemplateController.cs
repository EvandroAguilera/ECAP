using ECAP.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECAP.Controllers
{
    public class TemplateController : Controller
    {

        private DataContext db = new DataContext();

        public ActionResult Index()
        {

            try
            {
                    HttpCookie cook = Request.Cookies["ECAP_UserData"];
                    if (cook != null)
                        return View();
                    else
                        return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            };


        }


        public JsonResult ControlarMenu()
        {

            try
            {
                List<Menu> lMenu = new List<Menu>();

                DataTable dt;


                lMenu.Add(getMenu());
                foreach (Menu item in lMenu)
                {
                    item.lSubMenu.Add(new SubMenu { titule = "Agenda", action = "/Evandro/Agenda/Index" });
                }
                return new JsonResult() { Data = new { success = true, menu = lMenu } };

            }
            catch (Exception ex)
            {

                return new JsonResult() { Data = new { success = false, ex.Message } };
            }
            finally
            {
            }

        }

        public Menu getMenu()
        {
            Menu menus = new Menu();

            menus.titule = "Administrador";
            menus.icon = "mdi mdi-chart-bar";
            return menus;
        }
     
        public class Menu
        {
            public string titule { get; set; }

            public string icon { get; set; }

            public List<SubMenu> lSubMenu { get; set; }

            public Menu()
            {
                this.lSubMenu = new List<SubMenu>();
            }

        }

        public class SubMenu
        {
            public string titule { get; set; }

            public string action { get; set; }
        }



        public ActionResult Central()
        {
            return View();
        }

    }
}