using CanditateTesting.HernanySantos.Helpers;

namespace CanditateTesting.HernanySantos.Services
{
    public class HttpService : IHttpService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public void ConfigureHttp(string sourceUrl)
        {
            _httpClient.BaseAddress = new Uri(sourceUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> LoadFile(string url, string queryString = null)
        {
            string response = string.Empty;

            ConfigureHttp(url);

            Console.WriteLine($"Solicita comunicação para obter arquivo de origem - {url}");
            var responseMessage = new HttpResponseMessage();

            try
            {
                Console.WriteLine("Realiza requisição de dados do arquivo");
                responseMessage = await _httpClient.GetAsync(queryString);

                Console.WriteLine("Aguarde ......");

                if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new HttpRequestException($"Falha de Requisição...: {responseMessage.StatusCode}-{responseMessage.RequestMessage}");
                }

                response =  await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}