using CanditateTesting.HernanySantos.Services;

namespace CandidateTesting.HernanySantos.Tests
{
    public class HttpServiceTest
    {
        [Theory(DisplayName = "Obter Dados do Source via requisição Http")]
        [Trait("Categoria", "HttpService")]
        [InlineData("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt")]
        public async void FonteDeDados_CarregarDadosDoArquivoDoSource_DeveRetornarSucesso(string sourceUrl) 
        {
            var response = await new HttpService().LoadFile(sourceUrl, null);

            Assert.NotNull(response);
        }

        [Theory(DisplayName = "Receber falha ao tentar Obter Dados do Source via requisição Http")]
        [Trait("Categoria", "HttpService")]
        [InlineData("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.err")]
        public async void FonteDeDados_CarregarDadosDoArquivoDoSource_DeveRetornarException(string sourceUrl) 
        {
            //var response = await new HttpService().LoadFile(sourceUrl, null);

            Assert.ThrowsAsync<InvalidOperationException>(() => new HttpService().LoadFile(sourceUrl, null));
        }
    }
}