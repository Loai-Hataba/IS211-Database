using Microsoft.Extensions.Configuration;
using MovieRental.AuthForms ;
namespace MovieRental
{
    internal static class Program
    {
        public static IConfiguration Configuration { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            ApplicationConfiguration.Initialize();
            Application.Run(new ApplicationForm());
        }
    }
}