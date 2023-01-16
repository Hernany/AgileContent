using CanditateTesting.HernanySantos.Models;

namespace CanditateTesting.HernanySantos.Services
{
    public interface IFileService
    {
        bool CreateFileTarget(List<Target> lstTarget, string targetPath);
    }
}