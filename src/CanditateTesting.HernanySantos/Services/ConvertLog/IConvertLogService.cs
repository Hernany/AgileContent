using CanditateTesting.HernanySantos.Models;

namespace CanditateTesting.HernanySantos.Services
{
    public interface IConvertLogService
    {
        Task<bool> ConvertLog(string sourceUrl, string targetPath);
    }
}