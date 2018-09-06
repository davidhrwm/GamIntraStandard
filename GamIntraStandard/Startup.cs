using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;


[assembly: OwinStartupAttribute(typeof(GamIntraStandard.Startup))]
namespace GamIntraStandard
{
    public partial class Startup
    {
        //
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //
        }
    }
}