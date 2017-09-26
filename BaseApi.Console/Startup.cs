using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace BaseApi.Console
{
    public class Startup : Web.Startup
    {
        public override void Configuration(IAppBuilder app)
        {
            // Set the path to the actual static files.
            var relativePath = string.Format(@"..{0}..{0}..{0}/BaseApi.Web{0}", Path.DirectorySeparatorChar);
            string contentPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);

            var physicalFileSystem = new PhysicalFileSystem(contentPath);

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem,
                StaticFileOptions =
                {
                    FileSystem = physicalFileSystem,
                    ServeUnknownFileTypes = true,
                },
                DefaultFilesOptions = { DefaultFileNames = new List<string> {"index.htnl"} }
            };

            app.UseFileServer(options);

            // Call the base for the rest.
            base.Configuration(app);
        }
    }
}
