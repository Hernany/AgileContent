using CanditateTesting.HernanySantos.Helpers;
using CanditateTesting.HernanySantos.Models;
using Microsoft.Extensions.Logging;
namespace CanditateTesting.HernanySantos.Services
{
    public class ConvertLogService : IConvertLogService
    {
        private readonly IHttpService _httpService;

        private readonly IFileService _fileService;

        public ConvertLogService(IHttpService httpService, IFileService fileService)
        {
            _httpService = httpService;
            _fileService = fileService;
        }

        public async Task<bool> ConvertLog(string sourceUrl, string targetPath)
        {
            try
            {
                Console.WriteLine("Processando ....... ");

                Console.WriteLine($"Source...: {sourceUrl} - Target...: {targetPath} ");

                var responseData =  Mapper.ConvertToAgora(await _httpService.LoadFile(sourceUrl));

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Resposta HTTP ...: OK");
                Console.WriteLine("------------------------------------------------------------");

                return _fileService.CreateFileTarget(responseData, targetPath);    
            }
            catch (Exception ex)
            {
                Util.Error();
                throw ex;
            }
            
        }
    }
}