using Xunit;
using Moq;
using AutoMapper;
using Totvs.Locadora.Infrastructure;
using Totvs.Locadora.Api.Controllers;
using Totvs.Locadora.Api.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Totvs.Locadora.Testes
{
    public class FilmesControllerEndpointInsereFilme
    {
        [Fact]
        public async Task DadoFilmeComInformacoesValidasDeveRetornar200()
        {
            //arrange

            var mockMapper = new Mock<IMapper>();
            var mockRepo = new Mock<IFilmeServicos>();
            var filmeController = new FilmesController(mockRepo.Object, mockMapper.Object);

            var filmeViewModel = new FilmeViewModel
            {
                DataLancamento = "2020-10-12",
                Genero = "Terror",
                Preco = 45.99,
                Titulo = "Drácula"
            };

            //act
            var result = await filmeController.InsereFilme(filmeViewModel);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DadoFilmeComInformacoesInvalidasDeveRetornar400()
        {
            // arrange

            var mockMapper = new Mock<IMapper>();
            var mockRepo = new Mock<IFilmeServicos>();
            var filmeController = new FilmesController(mockRepo.Object, mockMapper.Object);

            var filmeViewModel = new FilmeViewModel
            {
                DataLancamento = "",
                Preco = 45.99,
                Titulo = "Drácula"
            };

            // act

            var result = await filmeController.InsereFilme(filmeViewModel);

            //assert

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
