using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GeneralSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
			BuildWebHost(args).Run();
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("hosting.json", optional: true)
				.Build();

			var host = new WebHostBuilder()
				.UseConfiguration(config)
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls("http://*:5000")
                .Build();

		/// Some notes:
		/// 1. Copy folder to server by SSH:
		///    > scp -r /Users/huyquan/Projects/huyqta/GeneralSite.git/GeneralSite/bin/Release/PublishOutput/ root@128.199.210.158:/root/deploy/
		/// 2. Recover SSH:
		///    > eval `ssh-agent -s`
		///    > ssh-add /Users/huyquan/sshmac
        /// 3. Kill process by running on port 80 (Example): Sometimes, you cannot start the nginx because of the port was exist.
		///    > sudo fuser -k 80/tcp
        /// Nginx: 80
        /// Apaches: 8080
        /// Jenkins: 9999
	}
}
