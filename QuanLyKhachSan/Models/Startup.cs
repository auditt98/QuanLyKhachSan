using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyKhachSan.Startup))]
namespace QuanLyKhachSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
