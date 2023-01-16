using System.Text;
using CanditateTesting.HernanySantos.Helpers;
using CanditateTesting.HernanySantos.Models;

namespace CanditateTesting.HernanySantos.Services
{
    public class FileService : IFileService
    {
        public bool CreateFileTarget(List<Target> lstTarget, string targetPath)
        {
            var response = false;

            try
            {
                if (lstTarget?.Any() == true) 
                {
                    Console.WriteLine("Preparando Arquivo de Log ....");
                    System.IO.FileInfo file = new System.IO.FileInfo(targetPath);

                    Console.WriteLine("Verificando Diretório ....");
                    file.Directory.Create();

                    Console.WriteLine("Gravando Log ....");
                    System.IO.File.WriteAllText(file.FullName, Mapper.ConvertToText(lstTarget));

                    Console.WriteLine($"Arquivo de Log Gravado ....: {file.FullName}");

                    response = true;
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return response;
        }
    }
}