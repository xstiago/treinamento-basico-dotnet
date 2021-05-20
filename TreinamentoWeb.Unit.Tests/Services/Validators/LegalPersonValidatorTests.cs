using FluentValidation.TestHelper;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Services.Validators;
using Xunit;

namespace TreinamentoWeb.Unit.Tests.Services.Validators
{
    public class LegalPersonValidatorTests
    {
        [Fact]
        public void ShouldValidateCnpjWhenCnpjIsValid()
        {
            #region Arrange

            var payload = new LegalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CNPJ = "05482826000158",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var validator = new LegalPersonValidator();

            #endregion Arrange

            #region Act/Assert

            validator.ShouldNotHaveValidationErrorFor(o => o.CNPJ, payload);

            #endregion Act/Assert
        }

        [Fact]
        public void ShouldNotValidateCnpjWhenCnpjIsInvalid()
        {
            #region Arrange

            var payload = new LegalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CNPJ = "05482826000157",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var validator = new LegalPersonValidator();

            #endregion Arrange

            #region Act/Assert

            validator.ShouldHaveValidationErrorFor(o => o.CNPJ, payload);

            #endregion Act/Assert
        }

        [Fact]
        public void ShouldNotValidateCnpjWhenCnpjIsNull()
        {
            #region Arrange

            var payload = new LegalPerson
            {
                Active = true,
                Address = "Rua XXX",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var validator = new LegalPersonValidator();

            #endregion Arrange

            #region Act/Assert

            validator.ShouldHaveValidationErrorFor(o => o.CNPJ, payload);

            #endregion Act/Assert
        }
    }
}
