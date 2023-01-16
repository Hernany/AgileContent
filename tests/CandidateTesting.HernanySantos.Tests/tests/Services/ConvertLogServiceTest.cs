using AutoFixture;
using CanditateTesting.HernanySantos.Helpers;
using CanditateTesting.HernanySantos.Models;
using CanditateTesting.HernanySantos.Services;
using Moq;

namespace CandidateTesting.HernanySantos.Tests
{
    public class ConvertLogServiceTest
    {
        [Theory(DisplayName = "Converter dados recebidos no Source em Target com Sucesso")]
        [Trait("Categoria", "ConvertLog")]
        [InlineData("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", "./output/minhaCdn1.txt")]
        public async void ConvertLog_ConvertendoSourceEmTarget_DeveRetornarSucesso(string sourceUrl, string targetPath)
        {
            var httpServiceMock = new Mock<IHttpService>();
            var fileServiceMock = new Mock<IFileService>();

            var responseHttpService = string.Empty;
            var responseFileService = true;

            httpServiceMock
                .Setup(httpService => httpService.LoadFile(It.IsAny<string>(), null))
                .Returns(Task.FromResult(responseHttpService));

            fileServiceMock
                .Setup(fileService => fileService.CreateFileTarget(Mapper.ConvertToAgora(responseHttpService), targetPath))
                .Returns(responseFileService);

            var convertLogService = new ConvertLogService(httpServiceMock.Object, fileServiceMock.Object);

            var response = convertLogService.ConvertLog(sourceUrl, targetPath);

            httpServiceMock.Verify(httpService => httpService.LoadFile(It.IsAny<string>(), null), Times.Once);
            fileServiceMock.Verify(fileService => fileService.CreateFileTarget(It.IsAny<List<Target>>(), It.IsAny<string>()), Times.Once);

            Assert.True(await response);
        }

        [Theory(DisplayName = "Converter dados recebidos no Source em Target com Falha")]
        [Trait("Categoria", "ConvertLog")]
        [InlineData("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", "./output/minhaCdn1.txt")]
        public async void ConvertLog_ConvertendoSourceEmTarget_DeveRetornarFalha(string sourceUrl, string targetPath)
        {
            var httpServiceMock = new Mock<IHttpService>();
            var fileServiceMock = new Mock<IFileService>();

            var responseHttpService = string.Empty;
            var responseFileService = false;

            httpServiceMock
                .Setup(httpService => httpService.LoadFile(It.IsAny<string>(), null))
                .Returns(Task.FromResult(responseHttpService));

            fileServiceMock
                .Setup(fileService => fileService.CreateFileTarget(Mapper.ConvertToAgora(responseHttpService), targetPath))
                .Returns(responseFileService);

            var convertLogService = new ConvertLogService(httpServiceMock.Object, fileServiceMock.Object);

            var response = convertLogService.ConvertLog(sourceUrl, targetPath);

            httpServiceMock.Verify(httpService => httpService.LoadFile(It.IsAny<string>(), null), Times.Once);
            fileServiceMock.Verify(fileService => fileService.CreateFileTarget(It.IsAny<List<Target>>(), It.IsAny<string>()), Times.Once);

            Assert.False(await response);
        }
    }
}