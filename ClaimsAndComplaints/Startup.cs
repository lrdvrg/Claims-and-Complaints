using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClaimsAndComplaints.Startup))]
namespace ClaimsAndComplaints
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
