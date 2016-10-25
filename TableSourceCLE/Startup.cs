using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TableSourceCLE.Startup))]
namespace TableSourceCLE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
