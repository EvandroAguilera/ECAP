using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(ECAP.Startup))]



namespace ECAP
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            //app.UseMvc();
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Return From Run.");
            //});
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = "ApplicationCookie",
            //    LoginPath = new PathString("/Login/")
            //});

        }

    }
}