using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Services.Services;
using TreinamentoWeb.Services.Validators;
using Xunit;

namespace TreinamentoWeb.Unit.Tests.Services
{
    public class NaturalPersonServiceTests
    {
        [Fact]
        public async Task ShouldSaveDataWhenValidationWorks()
        {
            #region Arrange

            const int expectedChangedRecords = 1;

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "54822590054",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var repositoryMock = new Mock<IRepository<NaturalPerson>>();
            repositoryMock.Setup(o => o.Save(payload))
                .ReturnsAsync(1);

            var validator = new NaturalPersonValidator();

            var service = new NaturalPersonService(repositoryMock.Object, validator);
                      


            #endregion Arrange

            #region Act

            (int changedRecords, IEnumerable<string> errors) = await service.Save(payload);

            #endregion Act

            #region Assert

            Assert.Equal(expectedChangedRecords, changedRecords);
            Assert.Null(errors);

            #endregion Assert
        }

        [Fact]
        public async Task ShouldNotSaveDataWhenValidationDoesntWork()
        {
            #region Arrange

            const int expectedChangedRecords = -1;

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "54822590053",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var repositoryMock = new Mock<IRepository<NaturalPerson>>();

            var validator = new NaturalPersonValidator();

            var service = new NaturalPersonService(repositoryMock.Object, validator);

            #endregion Arrange

            #region Act

            (int changedRecords, IEnumerable<string> errors) = await service.Save(payload);

            #endregion Act

            #region Assert

            Assert.Equal(expectedChangedRecords, changedRecords);
            Assert.NotNull(errors);
            Assert.NotEmpty(errors);

            #endregion Assert
        }
    }
}
