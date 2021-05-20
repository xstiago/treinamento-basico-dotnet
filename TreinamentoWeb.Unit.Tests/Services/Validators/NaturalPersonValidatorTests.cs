using FluentValidation.TestHelper;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Services.Validators;
using Xunit;

namespace TreinamentoWeb.Unit.Tests.Services.Validators
{
    public class NaturalPersonValidatorTests
    {
        [Fact]
        public void ShouldValidateCpfWhenCpfIsValid()
        {
            #region Arrange

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "54822590054",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var validator = new NaturalPersonValidator();

            #endregion Arrange

            #region Act/Assert

            validator.ShouldNotHaveValidationErrorFor(o => o.CPF, payload);

            #endregion Act/Assert
        }

        [Fact]
        public void ShouldNotValidateCpfWhenCpfIsInvalid()
        {
            #region Arrange

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "54822590053",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var validator = new NaturalPersonValidator();

            #endregion Arrange

            #region Act/Assert

            validator.ShouldHaveValidationErrorFor(o => o.CPF, payload);

            #endregion Act/Assert
        }

        [Fact]
        public void ShouldNotValidateCpfWhenCpfIsNull()
        {
            #region Arrange

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var validator = new NaturalPersonValidator();

            #endregion Arrange

            #region Act/Assert

            validator.ShouldHaveValidationErrorFor(o => o.CPF, payload);

            #endregion Act/Assert
        }
    }
}
