using ECAP.DAO;
using ECAP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ECAP.Controllers
{
    public class LoginController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Usuario
        public ActionResult Index(string msg)
        {
            List<string> keys = new List<string>();
            IDictionaryEnumerator enumerator = HttpContext.Cache.GetEnumerator();

            while (enumerator.MoveNext())
                keys.Add(enumerator.Key.ToString());

            for (int i = 0; i < keys.Count; i++)
                HttpContext.Cache.Remove(keys[i]);

            //FIM DO LIMPAR CACHE


            HttpCookie cook = getCookie();

            cook.Values["dsLogin"] = null;
            cook.Values["dsEmail"] = null;

            cook.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Response.AppendCookie(cook);

            ViewData.Add("requerLogin", true);
            ViewData.Remove("msg");
            if (msg != null)
                ViewData.Add("msg", msg);


            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return View();
        }

        [HttpPost]
        public ActionResult Index(string loginUsername, string loginPassword)
        {
            Boolean ret = false;

            try
            {
           //       Usuario usuario = db.Usuario.Find(loginUsername);
                Usuario usuario = new Usuario();
                //Byte[] senhaAtual = encrypt(loginPassword);

                //ret = comparepwd(usuario.bnSenha, senhaAtual);

                if (true)
                {
                    usuario.dsLogin = "Evandro";
                    HttpCookie cook = getCookie();
                    cook.Values["dsLogin"] = usuario.dsLogin;

                    Response.Cookies.Add(cook);
                    int tempo = int.Parse("0" + ConfigurationManager.AppSettings["IntervaloCookieExpira"]);
                    TimeSpan somarTempo = new TimeSpan(0, 0, tempo > 0 ? tempo : 10, 0);
                    cook.Expires = DateTime.Now + somarTempo;

                    return RedirectToAction("Index", "Template");
                }
                else
                {
                    ViewData["TxtAviso"] = "Usuário ou senha inválidos! Verifique os valores informados.";
                    return View();
                }

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

        public byte[] encrypt(string pwd)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pwd);

            return md5.ComputeHash(inputBytes);
        }

        private bool comparepwd(byte[] pwd1, byte[] pwd2)
        {
            bool bEqual = false;
            if (pwd1.Length == pwd2.Length)
            {
                int i = 0;
                while ((i < pwd1.Length) && (pwd1[i] == pwd2[i]))
                    i += 1;
                if (i == pwd1.Length)
                    bEqual = true;
            }
            return bEqual;
        }

        private HttpCookie getCookie()
        {
            HttpCookie cook = Request.Cookies["ECAP_UserData"];
            if (cook == null)
            {
                cook = new HttpCookie("ECAP_UserData");
                cook.Path = "/";
            }
            return cook;
        }
    }
}