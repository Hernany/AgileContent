using AutoFixture;
using CanditateTesting.HernanySantos.Helpers;
using CanditateTesting.HernanySantos.Models;
using CanditateTesting.HernanySantos.Services;
using Moq;

namespace CandidateTesting.HernanySantos.Tests
{
    public class FileServiceTest
    {
        [Theory(DisplayName = "Obter Dados do Source via requisição Http")]
        [Trait("Categoria", "Agora")]
        [InlineData("./output/minhaCdn1.txt")]
        public async void CriarArquivoAgora_GerarArquivoComLayoutAgora_DeveRetornarSucesso(string targetPath) 
        {
            var lstTarget = new List<Target>();
            const string quote = "\"";
            var data = $@"312|200|HIT| {quote}GET /robots.txt HTTP/1.1{quote} |100.2";
            var source = new Source().ToSource(data);
            var target = new Target().ToTarget(source);

            lstTarget.Add(target);

            var response = new FileService().CreateFileTarget(lstTarget, targetPath);

            Assert.True(response);
        }
    }
}