using CanditateTesting.HernanySantos.Models;

namespace CandidateTesting.HernanySantos.Tests
{
    public class TargetTest
    {
        [Fact(DisplayName = "Adicionar dado no objeto Target")]
        [Trait("Categoria", "Target")]
        public void AdicionarNovoItem_NovoTarget_DeveObterSucesso() 
        {
            const string quote = "\"";
            var data = $@"312|200|HIT| {quote}GET /robots.txt HTTP/1.1{quote} |100.2";
            var source = new Source().ToSource(data);
            var target = new Target().ToTarget(source);

            Assert.NotNull(target);
        }

        [Fact(DisplayName = "Não adicionar dado no objeto Target caso o conteudo recebido seja inválido")]
        [Trait("Categoria", "Target")]
        public void AdicionarNovoItem_NovoTarget_DeveRetornarException() 
        {
            var data = $@"312|200|HIT| |100.2";
            var source = new Source().ToSource(data);
            source.UriPath = string.Empty;

            Assert.Throws<IndexOutOfRangeException>(() => new Target().ToTarget(source));
        }
    }
}