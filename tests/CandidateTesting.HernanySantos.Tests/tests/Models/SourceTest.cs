using CanditateTesting.HernanySantos.Models;

namespace CandidateTesting.HernanySantos.Tests
{
    public class SourceTest
    {
        [Fact(DisplayName = "Adicionar dado no objeto Source")]
        [Trait("Categoria", "Source")]
        public void AdicionarNovoItem_NovoSource_DeveObterSucesso() 
        {
            const string quote = "\"";
            var data = $@"312|200|HIT| {quote}GET /robots.txt HTTP/1.1{quote} |100.2";
            var source = new Source().ToSource(data);

            Assert.NotNull(source);
        }

        [Fact(DisplayName = "Não adicionar dado no objeto Source caso o conteudo recebido seja vazio")]
        [Trait("Categoria", "Source")]
        public void AdicionarNovoItem_NovoSource_DeveRetornarException() 
        {
            Assert.Throws<FormatException>(() => new Source().ToSource(""));
        }
    }
}