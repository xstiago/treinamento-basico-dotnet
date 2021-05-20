using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Services.Helpers;
using Xunit;

namespace TreinamentoWeb.Unit.Tests.Services.Helpers
{
    public class DocumentCustomerHelperTests
    {
        [Fact]
        public async Task ShouldReturnTrueWhenCpfIsValid()
        {
            #region Arrange

            const string cpf = "54822590054";

            #endregion Arrange

            #region Act

            var sucess = DocumentCustomerHelper.ValidateCpf(cpf);

            #endregion Act

            #region Assert

            Assert.True(sucess);

            #endregion Assert
        }
    }
}
