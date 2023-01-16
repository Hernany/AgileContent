using CanditateTesting.HernanySantos.Helpers;

namespace CandidateTesting.HernanySantos.Tests;

public class UtilTest
{
    //Validar se argumentos informados são validos

    [Fact(DisplayName = "Validar se os argumentos de entrada foram informados")]
    [Trait("Categoria", "Argumentos de Entrada")]
    public void ArgumentosDeEntrada_ValidarArgumentosInformados_DeveTerSucesso()
    {
        var source = "http://logstorage.com/minhaCdn1.txt";
        var target = "./output/minhaCdn1.txt";

        string[] argumentos = {source, target};

        var response = Util.ParameterIsValid(argumentos);

        Assert.True(response);
    }

    [Fact(DisplayName = "Validar quantidade de argumentos informados acima do esperado")]
    [Trait("Categoria", "Argumentos de Entrada")]
    public void ArgumentosDeEntrada_ValidarQuantidadeArgumentosInformadosAcimaDoEsperado_DeveTerSucesso()
    {
        var source = "http://logstorage.com/minhaCdn1.txt";
        var target = "./output/minhaCdn1.txt";
        var optional = "./output/minhaCdn1.txt";

        string[] arguments = {source, target, optional};

        var response = Util.ParameterIsValid(arguments);

        Assert.True(response);
    }

    [Fact(DisplayName = "Validar quantidade de argumentos informados abaixo do esperado")]
    [Trait("Categoria", "Argumentos de Entrada")]
    public void ArgumentosDeEntrada_ValidarQuantidadeArgumentosInformadosAbaixoDoEsperado_DeveTerFalha()
    {
        var source = "http://logstorage.com/minhaCdn1.txt";

        string[] arguments = {source};

        var response = Util.ParameterIsValid(arguments);

        Assert.False(response);
    }

    [Fact(DisplayName = "Validar quando argumentos não informados")]
    [Trait("Categoria", "Argumentos de Entrada")]
    public void ArgumentosDeEntrada_ValidarQuantidadeArgumentosNaoInformados_DeveTerFalha()
    {
        string[] arguments = {};

        var response = Util.ParameterIsValid(arguments);

        Assert.False(response);
    }
}