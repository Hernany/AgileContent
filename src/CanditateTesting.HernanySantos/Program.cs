using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CanditateTesting.HernanySantos.Services;
using CanditateTesting.HernanySantos.Helpers;

namespace CandidateTesting.HernanySantos.AgileContent
{
    class Program 
    {
        static void Main(string[] args)
        {
            try
            {
                Util.Header();

                ExecuteLogger(args);

                Util.Footer();    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void ExecuteLogger(string[] args) 
        {
            var serviceCollection = new ServiceCollection();
            Config.ConfigureServices(serviceCollection);
            var eventConvertLogService = serviceCollection.BuildServiceProvider().GetService<IConvertLogService>();

            if(Util.ParameterIsValid(args))
                eventConvertLogService.ConvertLog(args[0], args[1]).Wait();
        }
    }
}
