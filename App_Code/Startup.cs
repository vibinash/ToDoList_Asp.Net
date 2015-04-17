using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoForm.Startup))]
namespace TodoForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
