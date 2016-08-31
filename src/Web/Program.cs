using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Server.Kestrel.Https;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                //(options => options.UseHttps( new HttpsConnectionFilterOptions(){
                //    ServerCertificate = new X509Certificate2(@"C:\Users\rengwer\desktop\TempCA.cer", "bob"),
                //    ClientCertificateMode = ClientCertificateMode.RequireCertificate
                //}))
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
