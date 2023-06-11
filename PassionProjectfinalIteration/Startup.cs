using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassionProjectfinalIteration.Startup))]
namespace PassionProjectfinalIteration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
