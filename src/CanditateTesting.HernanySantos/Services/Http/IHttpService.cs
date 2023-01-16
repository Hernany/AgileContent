namespace CanditateTesting.HernanySantos.Services
{
    public interface IHttpService
    {
        /// <summary>
        /// Ler url para leitura do arquivo de log
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<string> LoadFile(string url, string queryString = null);
    }
}