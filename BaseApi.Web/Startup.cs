using System.Web.Http;
using BaseApi.Web.App_Start;
using Owin;

namespace BaseApi.Web
{
    public class Startup
    {
        public virtual void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}