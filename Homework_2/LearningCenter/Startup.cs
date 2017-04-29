using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningCenter.Startup))]
namespace LearningCenter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
