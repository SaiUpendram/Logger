public class Program
{
      
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .ConfigureLogging((hostBuilderContext, logging) =>
            {
                logging.AddDbLogger(options =>
                {
                    hostBuilderContext.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
                });
            });
            
            var builder = WebApplication.CreateBuilder(args);
 
             builder.Logging.AddDbLogger(options =>
            {
                builder.Configuration.GetSection("Logging").GetSection("Database").GetSection("Options").Bind(options);
            });

            var app = builder.Build();
            app.Run();
}
